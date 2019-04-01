using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Services.Offer.API.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Offer.API.Module.Offer
{
    public class OfferRedisRepository : IOfferRepository
    {
        private readonly ILogger<OfferRedisRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        
        public OfferRedisRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<OfferRedisRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public IEnumerable<OfferModel> GetAllOffer()
        {
            var server = GetServer();
            var data = server.Keys();

            return data?.Select(k =>  new OfferModel() { Id = int.Parse(k.ToString()) });
        }

        public async Task<OfferModel> GetOfferAsync(string offerId)
        {
            var data = await _database.StringGetAsync(offerId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<OfferModel>(data);
        }

        public async Task<bool> AddOfferAsync(OfferModel offerModel)
        {
            var response = Task.FromResult(false);
            var data = await _database.StringGetAsync(offerModel.Id.ToString());

            if (data.IsNullOrEmpty)
            {
                var json = JsonConvert.SerializeObject(offerModel);
                response = _database.StringSetAsync(offerModel.Id.ToString(), json);
            }

            return await response;
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
    }
}

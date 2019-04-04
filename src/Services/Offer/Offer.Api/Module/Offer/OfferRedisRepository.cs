using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Services.Offer.API.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Offer.API.Common;
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
            OfferModel result = null;
            var key = OfferKeyCache.OfferKey(offerId);
            if (_database.KeyExists(key))
            {
                var data = await _database.StringGetAsync(key);
                result = JsonConvert.DeserializeObject<OfferModel>(data);
            }

            return result;
        }

        public async Task<bool> AddOfferAsync(OfferModel offerModel)
        {
            var objectJson = JsonConvert.SerializeObject(offerModel);
            var result = await _database.StringSetAsync(OfferKeyCache.OfferKey(offerModel.Id.ToString()), objectJson);

            return result;
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
    }
}

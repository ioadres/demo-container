using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Offer.API.Module.Offer
{
    public interface IOfferRepository
    {
        IEnumerable<OfferModel> GetAllOffer();
        Task<OfferModel> GetOfferAsync(string offerId);
        Task<bool> AddOfferAsync(OfferModel offerModel);
    }
}

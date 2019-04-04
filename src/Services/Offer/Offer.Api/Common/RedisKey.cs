using System;
namespace Offer.API.Common
{
    public static class OfferKeyCache
    {
        public const string OFFER_ITEM = "";
        public static Func<string,string> OfferKey = (string key) => $"{OFFER_ITEM}{key}";
    }
}

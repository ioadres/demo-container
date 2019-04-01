using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API
{
    public class OfferSetting
    {
        public string ConnectionString { get; set; }
        public Identity Identity { get; set; }
        public Health SelfUiHealth { get; set; }
        public Health SelfLiveHealth { get; set; }
    }

    public class Identity
    {
        public string Audience { get; set; }
        public string IdentityUrl { get; set; }
        public string IdentityUrlExternal { get; set; }
    }

    public class Health
    {
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}

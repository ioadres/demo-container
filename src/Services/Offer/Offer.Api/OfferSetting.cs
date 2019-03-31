using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API
{
    public class OfferSetting
    {
        public string ConnectionString { get; set; }
        public Health SelfUiHealth { get; set; }
        public Health SelfLiveHealth { get; set; }
    }

    public class Health
    {
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}

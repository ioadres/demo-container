using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API.Infrastructure.Middlewares.Failing
{
    public class FailingOptions
    {
        public string ConfigPath = "/Failing";
        public List<string> EndpointPaths { get; set; } = new List<string>();
    }
}

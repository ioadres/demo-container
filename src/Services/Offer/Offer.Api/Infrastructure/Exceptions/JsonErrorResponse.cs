using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API.Infrastructure.Exceptions
{
    public class JsonErrorResponse
    {
        public string[] Messages { get; set; }
       
    }

    public class JsonErrorDeveloperResponse : JsonErrorResponse
    {
        public object DeveloperMessage { get; set; }
    }
}

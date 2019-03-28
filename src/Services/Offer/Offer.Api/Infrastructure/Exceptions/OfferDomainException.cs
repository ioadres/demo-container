using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API.Infrastructure.Exceptions
{
    public class OfferDomainException : Exception
    {
        public OfferDomainException()
        { }

        public OfferDomainException(string message)
            : base(message)
        { }

        public OfferDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

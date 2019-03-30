using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Services.Offer.API.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Offer.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetError")]
        public ActionResult<IEnumerable<string>> GetError()
        {
            throw new NotImplementedException();
        }

        [HttpGet("GetErrorCustom")]
        public ActionResult<IEnumerable<string>> GetErrorCustom()
        {
            throw new OfferDomainException("Error manual");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DemoCore.Services.Offer.API.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Offer.API.Module.Offer;

namespace Offer.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public IOfferRepository _offerRepository { get; set; }

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        // GET api/offer
        [HttpGet]
        public ActionResult<IEnumerable<OfferModel>> Get()
        {
            return Ok(_offerRepository.GetAllOffer());
        }

        // GET api/offer/5
        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OfferModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OfferModel>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var model = await _offerRepository.GetOfferAsync(id.ToString());
            if(model != null)
            {
                return model;
            }

            return NotFound();
        }

        // POST api/offer
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OfferModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Post([FromBody] OfferModel offerModel)
        {
            if (offerModel.Id <= 0)
            {
                return BadRequest();
            }
            var response = await _offerRepository.AddOfferAsync(offerModel);
            if(response)
            {
                return response;
            }
            return Conflict("La oferta enviada ya existe");
        }       
    }
}
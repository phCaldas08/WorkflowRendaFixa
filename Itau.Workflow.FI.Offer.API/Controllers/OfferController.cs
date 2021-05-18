using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itau.Workflow.FI.Offer.Core.Offer.Init;
using Itau.Workflow.FI.Offer.Core.Offer.Queries.GetOfferById;
using Itau.Workflow.FI.Offer.Core.Offer.Queries.ListOffers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itau.Workflow.FI.Offer.API.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await Mediator.Send(new Init());

            return Ok();
        }

        [HttpGet("list_offers")]
        public async Task<ActionResult> GetOffers([FromQuery] ListOffersQuery requestBody)
        {
            var result = await Mediator.Send(requestBody);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOfferById([FromRoute] int id)
        {
            var result = await Mediator.Send(new GetOfferByIdQuery { IdOffer = id });

            return Ok(result);
        }

    }
}

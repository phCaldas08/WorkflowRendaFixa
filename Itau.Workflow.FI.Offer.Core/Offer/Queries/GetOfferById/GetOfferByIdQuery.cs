using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace Itau.Workflow.FI.Offer.Core.Offer.Queries.GetOfferById
{
    public class GetOfferByIdQuery : IRequest<Domain.Entities.Offer>
    {
        [JsonProperty("IdOffer")]
        public int IdOffer { get; set; }
    }
}

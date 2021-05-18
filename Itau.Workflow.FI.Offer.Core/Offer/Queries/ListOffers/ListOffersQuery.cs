using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace Itau.Workflow.FI.Offer.Core.Offer.Queries.ListOffers
{
    public class ListOffersQuery : IRequest<IEnumerable<Domain.Entities.Offer>>
    {
        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        public int Offset { get; set; }
    }
}

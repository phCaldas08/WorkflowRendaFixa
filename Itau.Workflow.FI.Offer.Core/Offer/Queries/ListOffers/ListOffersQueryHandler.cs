using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Itau.Workflow.FI.Offer.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itau.Workflow.FI.Offer.Core.Offer.Queries.ListOffers
{
    public class ListOffersQueryHandler : IRequestHandler<ListOffersQuery, IEnumerable<Domain.Entities.Offer>>
    {
        private HubDbContext dbContext;

        public ListOffersQueryHandler(HubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Offer>> Handle(ListOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await dbContext.Offers
                .Skip(request.Offset)
                .Take(request.PageSize)
                .ToListAsync();

            return offers;
        }
    }
}

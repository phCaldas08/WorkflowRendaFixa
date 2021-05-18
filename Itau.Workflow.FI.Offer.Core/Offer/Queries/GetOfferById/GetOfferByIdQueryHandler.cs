using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Itau.Workflow.FI.Offer.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itau.Workflow.FI.Offer.Core.Offer.Queries.GetOfferById
{

    public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, Domain.Entities.Offer>
    {

        private HubDbContext dbContext;

        public GetOfferByIdQueryHandler(HubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Domain.Entities.Offer> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var offer = await this.dbContext.Offers
                .FirstOrDefaultAsync(i => i.Id == request.IdOffer);

            return offer;
        }
    }
}

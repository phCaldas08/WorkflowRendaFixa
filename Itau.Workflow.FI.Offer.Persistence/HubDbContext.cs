using System;
using Microsoft.EntityFrameworkCore;

namespace Itau.Workflow.FI.Offer.Persistence
{
    public class HubDbContext : DbContext
    {

        public HubDbContext(DbContextOptions<HubDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Offer> Offers { get; set; }
        public DbSet<Domain.Entities.Indexer> Indexers { get; set; }
        public DbSet<Domain.Entities.InstructionCvm> InstructionsCvm { get; set; }

    }
}

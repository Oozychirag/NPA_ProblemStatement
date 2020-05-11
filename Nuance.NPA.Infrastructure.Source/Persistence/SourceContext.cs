using Nuance.NPA.Domain.Source.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nuance.NPA.Infrastructure.Source.Persistence
{
   public class SourceContext : DbContext
    {
        public SourceContext(DbContextOptions<SourceContext> options)
            : base(options)
        {
        }
        public DbSet<SourceEntity> Source { get; set; }
    }
}

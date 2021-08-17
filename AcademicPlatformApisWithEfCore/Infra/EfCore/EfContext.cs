using Microsoft.EntityFrameworkCore;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
        }
    }
}

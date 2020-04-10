using Microsoft.EntityFrameworkCore;

namespace CoordinatorWebpage.Data
{
    public class CoordinatorContext : DbContext
    {
        public CoordinatorContext (
            DbContextOptions<CoordinatorContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Coordinator> Coordinator { get; set; }
    }
}

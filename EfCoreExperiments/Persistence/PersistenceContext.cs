using EfCoreExperiments.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreExperiments.Persistence
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext()
        {
        }
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {
        }
        public DbSet<GiftCard> GiftCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EfCoreExperiments;Integrated Security=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GiftCardConfiguration());
        }

        public async new virtual Task<int> SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(e => typeof(IEntity).IsAssignableFrom(e.Entity.GetType()));
            var valueObjects = ChangeTracker.Entries().Where(e => !typeof(IEntity).IsAssignableFrom(e.Entity.GetType()));
            
            return  await base.SaveChangesAsync();
        }
    }
}

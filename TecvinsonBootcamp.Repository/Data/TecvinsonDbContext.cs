using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TecvinsonBootcamp.Domain.Common;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Data
{
    public class TecvinsonDbContext : DbContext
    {
        public TecvinsonDbContext(DbContextOptions<TecvinsonDbContext> options) : base (options)
        {
            
        }

        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(TecvinsonDbContext));
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TecvinsonDbContext))!);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        //entry.Entity.ModifiedBy = 
                        break;
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        //entry.Entity.CreatedBy = 
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

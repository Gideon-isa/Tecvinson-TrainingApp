using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

    }
}

using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasOne(a => a.Address)
                       .WithOne(a => a.Applicant)
                       .HasForeignKey<Address>(a => a.ApplicantId)
                       .IsRequired();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(a => a.Applicant)
                .WithOne(a => a.Address)
                .HasForeignKey<Applicant>(a => a.AddressId);
            });

            //base.OnModelCreating(modelBuilder);

            // Using the Fluent API Configuration
            // Configure one to one Relationship Between Applicant and Address
            //modelBuilder.Entity<Address>().HasKey(a => a.Applicant);

            //modelBuilder.Entity<Applicant>()
            //    .HasOne(ap => ap.Address) // Applicant has one to Address
            //    .WithOne(add => add.Applicant) // Address is associated one Applicant
            //    .HasForeignKey<Address>(add => add.ApplicantId);

            //modelBuilder.Entity<Applicant>()
            //    .HasMany<Address>(a => a.Addresses)
            //    .
                
            //    .HasForeignKey(a => a.ApplicantId);

            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.HasKey(a => a.Id);
            //    entity.HasOne(a => a.Applicant)
            //          .WithOne(a => a.Address)
            //          .HasForeignKey<Applicant>(a => a.AddressId)
            //          .OnDelete(DeleteBehavior.Restrict);
            //});
        }

    }
}

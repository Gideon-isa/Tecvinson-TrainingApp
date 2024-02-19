using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Configuration
{
    internal class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasOne(a => a.Address)
                .WithOne(a => a.Applicant)
                .HasForeignKey<Address>(a => a.ApplicantId)
                .IsRequired(); 
        }
    }
}

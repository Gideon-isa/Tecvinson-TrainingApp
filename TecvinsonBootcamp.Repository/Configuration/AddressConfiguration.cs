using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(a => a.Applicant)
                .WithOne(a => a.Address)
                .HasForeignKey<Applicant>(a => a.AddressId);
        }
    }
}

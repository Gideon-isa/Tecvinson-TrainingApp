using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            throw new NotImplementedException();
        }
    }
}

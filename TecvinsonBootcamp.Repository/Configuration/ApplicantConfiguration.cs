using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Configuration
{
    internal class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            throw new NotImplementedException();
        }
    }
}

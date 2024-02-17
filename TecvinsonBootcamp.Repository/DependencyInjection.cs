using Microsoft.Extensions.DependencyInjection;
using TecvinsonBootcamp.Domain.Repository;
using TecvinsonBootcamp.Repository.Implementation;

namespace TecvinsonBootcamp.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {           
            return services.AddScoped<IApplicantRepository, ApplicantRepository>();  
        }
    }
}

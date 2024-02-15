using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Repository;
using TecvinsonBootcamp.Services.Implementation;
using TecvinsonBootcamp.Services.Interfaces;

namespace TecvinsonBootcamp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicantServiceExtension
    {
        public static IServiceCollection AddApplicantServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicantService, ApplicantService>();
            return services;

        }
    }
}

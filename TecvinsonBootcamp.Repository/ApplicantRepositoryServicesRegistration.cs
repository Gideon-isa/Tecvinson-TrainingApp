﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Repository;
using TecvinsonBootcamp.Repository.Data;
using TecvinsonBootcamp.Repository.Implementation;

namespace TecvinsonBootcamp.Repository
{
    public static class ApplicantRepositoryServicesRegistration
    {
        public static IServiceCollection AddApplicantRepositoryServices(this IServiceCollection services)
        {
            
            return services.AddScoped<IApplicantRepository, ApplicantRepository>();
            

        }
    }
}
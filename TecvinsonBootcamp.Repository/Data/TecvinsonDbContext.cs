using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Repository.Data
{
    public class TecvinsonDbContext : DbContext
    {
        public TecvinsonDbContext(DbContextOptions<TecvinsonDbContext> options) : base (options)
        {
            
        }

        public DbSet<Applicant> Applicant { get; set; }

       

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Domain.Repository;
using TecvinsonBootcamp.Repository.Data;

namespace TecvinsonBootcamp.Repository.Implementation
{
    /// <summary>
    /// Applicant Repository class
    /// </summary>
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly TecvinsonDbContext _applicantDbContect;
        public ApplicantRepository(TecvinsonDbContext tecvinsonDbContext)
        {
            _applicantDbContect = tecvinsonDbContext;
        }

        /// <summary>
        /// Adding new applicant to the database
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task Add(Applicant applicant)
        {
            await _applicantDbContect.Applicant.AddAsync(applicant);
            await SaveChanges();
        }

        /// <summary>
        /// Retrieving all applicants
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Applicant>> GetAll()
        {
            return await _applicantDbContect.Applicant.ToListAsync();
        }

        /// <summary>
        /// Retrieving a single Applicant by its 
        /// </summary>
        /// <param name="id">Applicant's ID</param>
        /// <returns></returns>
        public async Task<Applicant> GetById(Guid id)
        {
           
            return await _applicantDbContect.Applicant.FirstOrDefaultAsync(a => a.Id == id);
             
        }

        /// <summary>
        /// Removing an applicant from the data base
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task Remove(Applicant applicant)
        {
            _applicantDbContect.Applicant.Remove(applicant);
            await SaveChanges();
        }

        /// <summary>
        /// Saving all changes in the DBContext to the database
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges()
        {
            _ = await _applicantDbContect.SaveChangesAsync();
        }
    }
    }
}

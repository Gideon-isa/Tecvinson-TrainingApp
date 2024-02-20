using Microsoft.EntityFrameworkCore;
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
        private readonly TecvinsonDbContext _applicantDbContext;
        public ApplicantRepository(TecvinsonDbContext tecvinsonDbContext)
        {
            _applicantDbContext = tecvinsonDbContext;
        }

        /// <summary>
        /// Adding new applicant to the database
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task Add(Applicant applicant)
        {
            await _applicantDbContext.Applicant.AddAsync(applicant);
            await SaveChanges();
        }

        /// <summary>
        /// Retrieving all applicants
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Applicant>> GetAll()
        {
            return await _applicantDbContext.Applicant.Include(a => a.Address).ToListAsync();
        }

        /// <summary>
        /// Retrieving a single Applicant by its 
        /// </summary>
        /// <param name="id">Applicant's ID</param>
        /// <returns></returns>
        public async Task<Applicant> GetById(Guid id)
        {
            var applicant = await _applicantDbContext.Applicant
                .Include(a => a.Address)
                .FirstOrDefaultAsync((a => a.Id == id));
            return applicant;
        }

        /// <summary>
        /// Removing an applicant from the data base
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task Remove(Guid applicantId)
        {
            var applicant = await _applicantDbContext
                .Applicant
                .Where(app => app.Id == applicantId)
                .FirstOrDefaultAsync();

            _ = _applicantDbContext.Applicant.Remove(applicant);
            await SaveChanges();
        }

        /// <summary>
        /// Saving all changes in the DBContext to the database
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges() 
        {
            _ = await _applicantDbContext.SaveChangesAsync();
        }

        public async Task<Applicant> Update(Applicant applicant)
        {
            _applicantDbContext.Entry(applicant).State = EntityState.Modified;
            await SaveChanges();
            return applicant;
        }

        

        
    }
    
}

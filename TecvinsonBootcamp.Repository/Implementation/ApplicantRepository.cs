using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Domain.Repository;

namespace TecvinsonBootcamp.Repository.Implementation
{
    public class ApplicantRepository : IApplicantRepository
    {
        public Task Add(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Applicant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}

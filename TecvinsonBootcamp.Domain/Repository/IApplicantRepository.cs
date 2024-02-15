using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Domain.Repository
{
    public interface IApplicantRepository
    {
        Task<Applicant> GetById(Guid id);
        Task<IEnumerable<Applicant>> GetAll();
        Task Add(Applicant applicant);

        Task<Applicant> Update(Applicant applicant);
        Task Remove(Guid applicantId);


    }
}

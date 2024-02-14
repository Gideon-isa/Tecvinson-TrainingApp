using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Domain.Interfaces
{
    public interface IApplicatsRepository
    {
        Task<Applicants> Add (Applicants applicants);
        Task<Applicants> Update(Applicants applicants);
        Task<Applicants> GetById(Guid applicants);
        Task<List<Applicants>> GetAll();
        Task <bool> Delete (Guid GroupID);
    }
}
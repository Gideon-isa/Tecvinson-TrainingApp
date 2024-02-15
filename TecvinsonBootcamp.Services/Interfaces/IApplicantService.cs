using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Services.Contracts;

namespace TecvinsonBootcamp.Services.Interfaces
{
    public interface IApplicantService
    {
        Task Add(ApplicantCreateReq applicant);
        Task<ApplicantDto> GetApplicantById(Guid id);
        Task<IEnumerable<ApplicantDto>> GetAllApplicants();
        Task Delete(Guid id);
        Task<ApplicantDto> Update(ApplicantUpdateReq applicant);
    }
}

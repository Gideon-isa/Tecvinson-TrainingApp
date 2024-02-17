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

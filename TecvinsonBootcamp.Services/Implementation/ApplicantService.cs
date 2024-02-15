using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Domain.Repository;
using TecvinsonBootcamp.Services.Contracts;
using TecvinsonBootcamp.Services.Extension;
using TecvinsonBootcamp.Services.Interfaces;

namespace TecvinsonBootcamp.Services.Implementation
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task Add(ApplicantCreateReq applicant)
        {
            // converting applicantCreateReq to Applicant Entity
            var newApplicant = applicant.AsEntity();

            // Adding the new applicant to the dbContext
            await _applicantRepository.Add(newApplicant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {

            await _applicantRepository.Remove(id);
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<ApplicantDto>> GetAllApplicants()
        {
            var applicants = await _applicantRepository.GetAll();

            List<ApplicantDto> applicantDtos = new List<ApplicantDto>();

            foreach (var item in applicants)
            {
                applicantDtos.Add(item.ToDto());
            }

            return applicantDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApplicantDto> GetApplicantById(Guid id)
        {
            var applicant = await _applicantRepository.GetById(id);
            return applicant.ToDto();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task<ApplicantDto> Update(ApplicantUpdateReq applicant)
        {
            Applicant newUpdatedApp = applicant.AsEntity();
            await _applicantRepository.Update(newUpdatedApp);

            return newUpdatedApp.ToDto();
            
        }
    }
}

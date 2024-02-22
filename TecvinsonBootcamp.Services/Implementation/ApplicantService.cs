using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Domain.Enums;
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
            //
            newApplicant.EmploymentStatus = GetEmploymentStatus(applicant.EmploymentStatus);        

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
            var checkApplicant = await _applicantRepository.GetById(applicant.Id);
            if (checkApplicant is null)
            {
                return null;
            }


            //checkApplicant = applicant.AsEntity(checkApplicant); // this not working ?????

            try
            {
                checkApplicant.EmploymentStatus = GetEmploymentStatus(applicant.EmploymentStatus);
            }
            catch (Exception e)
            {

                return null;
            }

            checkApplicant.FirstName = applicant.FirstName;
            checkApplicant.LastName = applicant.LastName;
            checkApplicant.Email = applicant.Email;
            checkApplicant.Phone = applicant.Phone;
            checkApplicant.Gender = applicant.Gender;
            checkApplicant.Nationality = applicant.Nationality;
            checkApplicant.DateOfBirth = applicant.DateOfBirth;
            //checkApplicant.EmploymentStatus = applicant.EmploymentStatus;
            checkApplicant.ExistingDevSkill = applicant.ExistingDevSkill;
            checkApplicant.MyDevSkills = applicant.MyDevSkills;
            checkApplicant.Address = new Address
            {
                HouseNumber = applicant.HouseNumber,
                State = applicant.State,
                Country = applicant.Country
            };

            return (await _applicantRepository.Update(checkApplicant)).ToDto();
   
        }

        private static EmploymentStatus GetEmploymentStatus(string userInput)
        {
            EmploymentStatus employmentStatus = EmploymentStatus.Worker;

            userInput = userInput.Trim().ToLower();

            if (userInput.Contains(" "))
            {
                userInput = userInput.Replace(" ", "");
            }
            switch (userInput)
            {
                case "worker":
                    employmentStatus = EmploymentStatus.Worker;
                    break;
                case "employee":
                    employmentStatus = EmploymentStatus.Employee;
                    break;
                case "selfemployed":
                    employmentStatus = EmploymentStatus.SelfEmployed;
                    break;
                case "unemployed":
                    employmentStatus = EmploymentStatus.Unemployed;
                    break;
                default:
                    throw null;
                    //break;
            }

            return employmentStatus;
        }
    }
}

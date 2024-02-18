using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Services.Contracts;

namespace TecvinsonBootcamp.Services.Extension
{
    public static class ApplicantExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static Applicant AsEntity(this ApplicantCreateReq req) 
        {
            return new Applicant
            {

                FirstName = req.FirstName,
                LastName = req.LastName,
                //Createdby = "Admin",
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkill = req.ExsitingDevSkill,
                MyDevSkills = req.MyDevSkills,
                DateCreated = DateTime.Now,
                EmploymentStatusConstant = req.EmploymentStatus,
                Address = new Address()
                {

                    HouseNumber = req.HouseNumber,
                    State = req.State,
                    Country = req.Country
                },


            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static Applicant AsEntity(this ApplicantUpdateReq req)
        {
            return new Applicant
            {

                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                Phone = req.Phone,
                Gender = req.Gender,
                Nationality = req.Nationality,
                DateOfBirth = req.DateOfBirth,
                ExistingDevSkill = req.ExistingDevSkill,
                MyDevSkills = req.MyDevSkills,
                DateModified = DateTime.Now,
                EmploymentStatusConstant = req.EmploymentStatus,
                Address = new Address
                {
                    HouseNumber = req.HouseNumber,
                    State = req.State,
                    Country = req.Country

                },
                AddressId = new Guid()
                
      
            };


        }

        public static ApplicantDto ToDto(this Applicant applicant)
        {
            return new ApplicantDto()
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                Phone = applicant.Phone,
                Gender = applicant.Gender,
                Nationality = applicant.Nationality,
                DateOfBirth = applicant.DateOfBirth,
                ExistingDevSkill = applicant.ExistingDevSkill,
                MyDevSkills = applicant.MyDevSkills,
                EmploymentStatus = applicant.EmploymentStatusConstant,
                Country = applicant.Address.Country,
                HouseNumber = applicant.Address.HouseNumber,
                State = applicant.Address.State
                //HouseNumber = applicant.Address.HouseNumber,
                //State = applicant.Address.State,
                //Country = applicant.Address.Country,
                //Address = applicant.Address
                //HouseNumber = applicant.Address.HouseNumber,
                //State = applicant.Address.State,
                //Country = applicant.Address.Country
                
            };
        }

        public static List<ApplicantDto> ToDtos(this IEnumerable<Applicant> applicants)
        {
            List<ApplicantDto> applicantDtos = new List<ApplicantDto>();

            foreach (var applicant in applicants)
            {
                var newApplicant =  new ApplicantDto()
                {
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    Email = applicant.Email,
                    Phone = applicant.Phone,
                    Gender = applicant.Gender,
                    Nationality = applicant.Nationality,
                    DateOfBirth = applicant.DateOfBirth,
                    ExistingDevSkill = applicant.ExistingDevSkill,
                    MyDevSkills = applicant.MyDevSkills,
                    EmploymentStatus = applicant.EmploymentStatusConstant,
                    Country = applicant.Address.Country,
                    HouseNumber = applicant.Address.HouseNumber,
                    State = applicant.Address.State
                    //HouseNumber = applicant.Address.HouseNumber,
                    //State = applicant.Address.State,
                    //Country = applicant.Address.Country,
                    //Address = applicant.Address
                    //HouseNumber = applicant.Address.HouseNumber,
                    //State = applicant.Address.State,
                    //Country = applicant.Address.Country

                };

                applicantDtos.Add(newApplicant);
            }

            return applicantDtos;
        }

        /// <summary>
        /// Converting the enum value to its respective string value
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        //private static string EmploymentStatusToString(Applicant applicant)
        //{
            
        //    string employmentStatus = string.Empty;

        //    int intValue = (int)applicant.EmploymentStatus;

        //    switch (intValue)
        //    {
        //        case 1:employmentStatus = "Worker";
        //            break;
        //        case 2: employmentStatus = "Employed";
        //            break;
        //        case 3: employmentStatus = "SelfEmployed";
        //            break;
        //        case 4: employmentStatus = "UnEmployed";
        //            break;
        //        default:
        //            employmentStatus = "";
        //            break;
        //    }

        //    return employmentStatus;
        //}
        
    }
}
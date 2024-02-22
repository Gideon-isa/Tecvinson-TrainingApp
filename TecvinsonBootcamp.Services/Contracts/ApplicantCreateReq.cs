using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TecvinsonBootcamp.Domain.Enums;

namespace TecvinsonBootcamp.Services.Contracts
{
    public class ApplicantCreateReq
    {
        public string? FirstName { set; get; } = string.Empty;
        public string? LastName { set; get; } = string.Empty;
        public string? Email { set; get; } = string.Empty;
        public string? Phone { set; get; } = string.Empty;
        public string? Gender { set; get; } = string.Empty;
        public string? Nationality { set; get; } = string.Empty;
        public DateTime DateOfBirth { set; get; }
        public List<string> ExsitingDevSkill { set; get; }
        public List<string> MyDevSkills { set; get; }
        //public EmploymentStatus EmploymentStatus { set; get; }
        public string EmploymentStatus { set; get; }

        //public Address Address { get; set; }

        public string? HouseNumber { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

    }
}
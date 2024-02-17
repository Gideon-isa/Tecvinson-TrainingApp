using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecvinsonBootcamp.Domain.Entities;

namespace TecvinsonBootcamp.Services.Contracts
{
    public class ApplicantDto
    {
        public string? FirstName { set; get; } = string.Empty;
        public string? LastName { set; get; } = string.Empty;
        public string? Email { set; get; } = string.Empty;
        public string? Phone { set; get; } = string.Empty;
        public string? Gender { set; get; } = string.Empty;
        public string? Nationality { set; get; } = string.Empty;
        public DateTime DateOfBirth { set; get; }
        public List<string> ExistingDevSkill { set; get; }
        public List<string> MyDevSkills { set; get; }

        public string EmploymentStatus { set; get; }

        //public Address? Address { get; set; }

        public string? HouseNumber { set; get; }
        public string? State { set; get; }
        public string? Country { set; get; }
    }
}

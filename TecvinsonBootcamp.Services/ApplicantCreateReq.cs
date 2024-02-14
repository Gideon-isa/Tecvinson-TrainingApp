using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Services
{
    public class ApplicantCreateReq
    {
        public Guid GroupID {set; get;}
        public string? FirstName {set; get;} = string.Empty;
        public string? LastName {set; get;} = string.Empty;
        public string? Email {set; get;} = string.Empty;
        public string? Phone {set; get;} = string.Empty;
        public string? Gender {set; get;} = string.Empty;
        public string? Nationality {set; get;} = string.Empty;
        public DateTime DateOfBirth {set; get;} = string.Empty;
        public List<string> ExsitingDevSkill {set; get;} = string.Empty;
        public List<string> MyDevSkills {set; get;} = string.Empty;

    }
}
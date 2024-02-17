using TecvinsonBootcamp.Domain.Common;

namespace TecvinsonBootcamp.Domain.Entities
{
    public class Applicant : Entity
    {
        public string FirstName {set; get;}
        public string LastName {set; get;} 
        public string Email {set; get;}
        public string? Phone {set; get;}
        public string Gender {set; get;}
        public string? Nationality {set; get;}
        public DateTime DateOfBirth {set; get;}
        public Guid GroupId { get; set; }
        public Address? Address { get; set; }
        public Guid AddressId { get; set; }

        public List<string> ExistingDevSkill { set; get; } = new List<string>();
        public List<string> MyDevSkills {set; get;} = new List<string>();
        public string? EmploymentStatusConstant{ set; get; }

    }
}
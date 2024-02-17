using System.Text.Json.Serialization;

namespace TecvinsonBootcamp.Domain.Entities
{
    public class Address
    {

        [JsonIgnore]
        public Guid Id { get; set; }    
        public string? HouseNumber { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant? Applicant { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Domain.Entities
{
    public class Address
    {

        [JsonIgnore]
        public Guid Id { get; set; }    
        public string HouseNumber { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        
    }
}

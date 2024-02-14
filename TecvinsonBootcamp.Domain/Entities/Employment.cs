using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Domain.Entities
{
    public class Employment
    {
         public bool CurrentlyEmployed { get; set; }
         public  List<string> EmploymentType { get; set; }
    }
}
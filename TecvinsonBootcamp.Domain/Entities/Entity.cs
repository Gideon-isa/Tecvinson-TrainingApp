using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Domain.Entities
{
    public class Entity
    {
         public Guid Id { set; get;}
        public string CreatedBy {set; get;} = string.Empty;
        public DateTime DateCreated {set; get;}
        public string ModifiedBy {set; get;} = string.Empty;
        public DateTime DateModified {set; get;}
    }
}
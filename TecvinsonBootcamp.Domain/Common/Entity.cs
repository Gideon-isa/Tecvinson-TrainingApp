using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecvinsonBootcamp.Domain.Common
{
    public class Entity
    {
        public Guid Id { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string CreatedBy { set; get; }
        public string ModifiedBy { set; get; }

    }
}
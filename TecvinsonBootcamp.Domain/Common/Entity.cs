using System.ComponentModel.DataAnnotations;

namespace TecvinsonBootcamp.Domain.Common
{
    public class Entity
    {
        //[Key] //
        public Guid Id { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string? CreatedBy { set; get; }
        public string? ModifiedBy { set; get; }

    }
}
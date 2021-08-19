using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Model.Base
{
    public class BaseEntity
    { 
        [Key]
        public long Id { get; set; }
    }
}

using SalesAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Model
{
    [Table("categories")]
    public class Category: BaseEntity
    {
        public string Description { get; set; }
        public bool Enabled { get; set; }

    }
}

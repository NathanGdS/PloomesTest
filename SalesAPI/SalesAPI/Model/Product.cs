using SalesAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Model
{
    [Table("products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public long CategoryId { get; set; }

        public Purchase Purchase { get; set; }
    }
}

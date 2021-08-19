using SalesAPI.Model.Base;

namespace SalesAPI.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public long CategoryId { get; set; }

        public Purchase Purchase { get; set; }
    }
}

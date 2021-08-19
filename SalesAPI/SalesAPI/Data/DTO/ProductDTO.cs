namespace SalesAPI.Data.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
    }
}

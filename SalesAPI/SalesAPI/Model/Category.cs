using SalesAPI.Model.Base;

namespace SalesAPI.Model
{
    public class Category: BaseEntity
    {
        public string Description { get; set; }
        public bool Enabled { get; set; }

    }
}

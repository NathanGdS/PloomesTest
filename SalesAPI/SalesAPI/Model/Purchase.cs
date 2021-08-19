using SalesAPI.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Model
{
    [Table("purchase")]
    public class Purchase : BaseEntity
    {
        public DateTime Date { get; set; }

        public long UserId { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}

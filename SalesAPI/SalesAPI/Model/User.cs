using SalesAPI.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string CompleteName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace catalina.Repositories.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirebaseToken { get; set; }
        public string PasswordEncrypt { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}

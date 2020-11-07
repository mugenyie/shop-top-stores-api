using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.ViewModels
{
    public class UserPostVM
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirebaseToken { get; set; }
        public string Password { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingAddress { get; set; }
    }
}

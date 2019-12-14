using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models.Customers
{
    public class CustomerModel
    {
        public string Id_Email { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int CountryNumber { get; set; }
    }
}
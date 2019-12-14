using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models.Customers
{
    public class RegisterCustomer
    {
        [Required]
        public string fld_Email { get; set; }
        [Required]
        public string fld_Name { get; set; }
        [Required]
        public string fld_Adress { get; set; }
        [Required]
        public string fld_Phone_No { get; set; }
        [Required]
        public string fld_Password { get; set; }
        [Required]
        public int fld_Country_Number { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class CustomerTable
    {
        public int fld_Customer_ID { get; set; }
        [Required]
        public string fld_Name { get; set; }
        public string fld_Email { get; set; }
        public string fld_Adress { get; set; }
        public int fld_Phone_No { get; set; }
        public string fld_Password { get; set; }

        //Foreign Key
        public int fld_Country { get; set; }
        // Navigation property 
        public CountryListTable countryList { get; set; }
    }
}
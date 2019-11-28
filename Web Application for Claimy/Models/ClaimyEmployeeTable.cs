using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class ClaimyEmployeeTable
    {
        public int empID { get; set; }
        [Required]
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public string password { get; set; }
        // foreign key
        public int country { get; set; }
        // navigation property 
        public CountryListTable countryList { get; set; }
    }
}
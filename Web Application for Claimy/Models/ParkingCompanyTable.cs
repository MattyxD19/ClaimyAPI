using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class ParkingCompanyTable
    {
        public int fld_CVRNO { get; set; }
        [Required]
        public string fld_Name { get; set; }

        public string fld_Adress { get; set; }

        public string fld_Email { get; set; }

        public int fld_Phone_No { get; set; }

        public string fld_Contact_Person { get; set; }

        //foreign key
        public int fld_Country { get; set; }

        // Navigation 
        public CountryListTable country { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class ZipcityTable
    {
        public int ID_Zipcode { get; set; }
        [Required]

        public string City { get; set; }

        //Foreign key
        public int ID_Country { get; set; }

        //navigation property
        public CountryList Country { get; set; } 
    }
}
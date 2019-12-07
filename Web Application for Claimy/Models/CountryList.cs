using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class CountryList
    {
        public int ID { get; set; }
        [Required]
        public string country { get; set; }
        public int zipcode { get; set; }
        public string city { get; set; }
    }
}
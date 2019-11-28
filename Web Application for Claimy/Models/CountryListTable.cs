using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class CountryListTable
    {
        public int id { get; set; }
        [Required]
        public string country { get; set; }
        public int zipcode { get; set; }
        public string city { get; set; }
    }
}
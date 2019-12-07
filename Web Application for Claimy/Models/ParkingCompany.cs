using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class ParkingCompany
    {

        /**
         * ID should be the CVR number
         * but the primary key cant be set
         * since the field accepts "ID" as a name
         */
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string ContactPerson { get; set; }

        //Foreing Key
        public CountryList Country { get; set; }
    }
}
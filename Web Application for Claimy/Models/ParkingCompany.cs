using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class ParkingCompany
    {
        /**
         * ID should be the CVR number
         * but the primary key cant be set
         * since the field accepts "ID" as a name
         */
        public string ID_CVR { get; set; }

        [Required]
        public string Name { get; set; }

        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }

        //Foreign key
        public int ID_Country { get; set; }
        //Navigation property
        public CountryList Country { get; set; }
    }
}
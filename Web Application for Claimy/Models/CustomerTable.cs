using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class CustomerTable
    {
        public string ID_Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Zipcode { get; set; }


        //Foreign key
        public int ID_Country { get; set; }

        //Navigation property
        public CountryList Country { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class CustomerTable
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public int Zipcode { get; set; }

        //Foreign Key
        public CountryList country { get; set; }
    }
}
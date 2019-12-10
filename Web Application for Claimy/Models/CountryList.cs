using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class CountryList
    {
        
        public int ID { get; set; }
        [Required]

        public string Country_Code { get; set; }

        public string Country_Name { get; set; }
    }
}
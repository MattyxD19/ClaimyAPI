using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class TicketTable
    {
        public string ID { get; set; }
        [Required]
        public string Law_Violation { get; set; }
        public int Tax_Number { get; set; }
        public DateTime Date { get; set; }
        public string Car_Registration { get; set; }
        public int ParkingSpaceID { get; set; }
        public int Traffic_WardenID { get; set; }
        public int TotalAmount { get; set; }
        public string Payment_Info { get; set; }
        public string Car_Brand { get; set; }

        //Foreign Keys
        public ParkingCompany CVRNumber { get; set; }
        public CustomerTable Customer_ID { get; set; }
    }
}
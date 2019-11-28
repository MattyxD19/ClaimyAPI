using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class TicketTable
    {
        public int fld_ID { get; set; }
        [Required]
        public string fld_Law_Violation { get; set; }

        public int fld_Tax_Number { get; set; }
        //
        public DateTime fld_Date_Time { get; set; }

        public int fld_Car_Reg_No { get; set; }

        public int fld_Parking_Space_ID { get; set; }

        public int fld_Traffic_Warden_No { get; set; }

        public int fld_Amount { get; set; }

        public string fld_Payment_Info { get; set; }

        public string fld_Car_Brand { get; set; }

        //foreign key(s)
        public int fld_CVRNO { get; set; }

        public int fld_Customer_ID { get; set; }

        // Navigation Property 
        public CustomerTable customer { get; set; }
        public ParkingCompanyTable parkingCompany { get; set; }



    }
}
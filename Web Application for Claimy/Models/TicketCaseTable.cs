using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class TicketCaseTable
    {
        [Required]
        public string ID_Case { get; set; }
        public string P_fineReason { get; set; }
        public string Precedens { get; set; }
        public string Status { get; set; }
        public string Law_Violation { get; set; }
        public string Tax_Number { get; set; }
        public DateTime Date { get; set; }
        public string Car_Registration { get; set; }
        public int ParkingSpaceID { get; set; }
        public int Traffic_WardenID { get; set; }
        public string TotalAmount { get; set; }
        public string Payment_Info { get; set; }
        public string Car_Brand { get; set; }

        // foreign key(s)
        public string EmpID_Email { get; set; }

        public string CustomerID_Email { get; set; }

        public string CVR_Parking_Company { get; set; }

        // navigation property
        public EmployeeTable ClaimyEmployee { get; set; }

        public ParkingCompany CVRNumber { get; set; }

        public CustomerTable Customer_ID { get; set; }
    }
}
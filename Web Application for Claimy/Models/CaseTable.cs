using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class CaseTable
    {
        public int ID { get; set; }
        [Required]
        public string P_fineReason { get; set; }
        public string Precedens { get; set; }
        public string Status { get; set; }
        // foreign key(s)  
        public int EmpID { get; set; }
        public int CustomerID { get; set; }
        // navigation property '
        public EmployeeTable ClaimyEmployee { get; set; }
        public CustomerTable Customer { get; set; }
    }
}
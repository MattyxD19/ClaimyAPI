using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Claimy.Models
{
    public class CaseTable
    {
    public string caseNo { get; set; }
        [Required]
    public string p_fineReason {get; set;}
    public string precedens { get; set; }
    public string status { get; set; }
     // foreign key(s)  
    public int empID { get; set; }
    public int customerID { get; set; }
     // navigation property '
     public ClaimyEmployeeTable claimyEmployee { get; set; }
     public CustomerTable customer { get; set; }

}
}
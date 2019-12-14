using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models.Customers
{
    public class CustomerUpdate
    {
        public string fld_Name { get; set; }
        public string fld_Adress { get; set; }
        public string fld_Phone_No { get; set; }
        public string fld_Password { get; set; }
        public int fld_Country_Number { get; set; }
    }
}
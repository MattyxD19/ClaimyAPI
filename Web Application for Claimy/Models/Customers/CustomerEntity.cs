using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Application_for_Claimy.EF;

namespace Web_Application_for_Claimy.Models
{
    public class CustomerEntity
    {
        public CustomerEntity()
        { 
        }
        public string fld_Email { get; set; }
        public string fld_Name { get; set; }
        public string fld_Adress { get; set; }
        public string fld_Phone_No { get; set; }
        public string fld_Password { get; set; }
        public int fld_Country_Number { get; set; } 
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public tbl_Country_List tbl_Country_List { get; internal set; }
    }
}
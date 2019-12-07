using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class Web_Application_for_ClaimyContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Web_Application_for_ClaimyContext() : base("name=Web_Application_for_ClaimyContext")
        {
        }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.CountryList> CountryLists { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.CustomerTable> CustomerTables { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.ParkingCompany> ParkingCompanies { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.TicketTable> TicketTables { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.ImageTable> ImageTables { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.EmployeeTable> EmployeeTables { get; set; }

        public System.Data.Entity.DbSet<Web_Application_for_Claimy.Models.CaseTable> CaseTables { get; set; }
    }
}

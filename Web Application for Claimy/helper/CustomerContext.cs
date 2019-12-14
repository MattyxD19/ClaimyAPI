using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Application_for_Claimy.Models;

namespace Web_Application_for_Claimy.helper
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEntityFramework.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseFirstApproach.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("conn")
        {
            
        }

        public DbSet<Worker> workers { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Products> products { get; set; }

    }
}
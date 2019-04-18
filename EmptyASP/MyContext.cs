using EmptyASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmptyASP
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }        
    }
}
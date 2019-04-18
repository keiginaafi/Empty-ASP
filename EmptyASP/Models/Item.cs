using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyASP.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public bool IsDelete { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}
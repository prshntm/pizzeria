using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext() : base("DefaultConnection")
        { }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<CustomPizza> CustomPizza { get; set; }
    }
}
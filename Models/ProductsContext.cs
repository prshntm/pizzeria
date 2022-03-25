using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class ProductsContext : DbContext//ассоциация модели данных Products с бд
    {
        public ProductsContext() : base("DefaultConnection")
        { }
        public DbSet<Products> Product { get; set; }
        public DbSet<CustomPizza> CustomPizzas{ get; set; }

    }
}
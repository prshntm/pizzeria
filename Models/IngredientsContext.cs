using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class IngredientsContext : DbContext
    {
        public IngredientsContext() : base("DefaultConnection")
        { }
        public DbSet<Ingredients> Ingredient { get; set; }
    }
}
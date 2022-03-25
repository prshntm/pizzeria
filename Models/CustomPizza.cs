using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class CustomPizza
    {
        [Key]
        public int PizzaID {
            get;/*{ return PizzaID = ProductID; }*/
            set; }
        public int ProductID { get; set; }
        public int IngredientID { get; set; }
        public decimal ProductPrice { get; /*{ return ProductPrice = (decimal)Products.ProductPrice; }*/ set; }
        public string PizzaName { get /*{ return PizzaName = Products.ProductName; }*/; set; }
        public Products Products { get; set; }
    }
}
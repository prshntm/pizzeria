using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class ShoppingCart //коллекция объектов Products
    {
        private IValueCalculator calc;
        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        public IEnumerable<Products> Product { get; set; }
        public double CalculateProductTotal()
        {
            return calc.ValueProducts(Product);
        }
    }
}
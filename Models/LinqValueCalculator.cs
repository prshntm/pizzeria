using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class LinqValueCalculator //класс для вычисления общей суммы для коллекции объектов Product
    {
        public double ValueProducts(IEnumerable<Products> products)
        {
            return products.Sum(p => p.ProductPrice);
        }
    }
}
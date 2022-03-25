using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public interface IValueCalculator
    {
        double ValueProducts(IEnumerable<Products> products);
    }
}
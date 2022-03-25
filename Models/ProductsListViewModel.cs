using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Product { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
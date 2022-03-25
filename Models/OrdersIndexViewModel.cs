using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class OrdersIndexViewModel
    {
        public IEnumerable<Orders> Order { get; set; }

    }
}
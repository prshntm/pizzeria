using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPizza.Models;

namespace WebPizza.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int OrderNum { get; set; }
        public int Quantity { get; set; }
        public double QuantityPrice { get; set; }
        public string OrderDateTime { get; set; }
        public string OrderStatus { get; set; }
        public Products Product { get; set; }
    }
    
}
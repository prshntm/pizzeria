using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class PizzaConstructorIndexViewModel
    {
        public PizzaConstructor PizzaConstructor { get; set; }
        public string ReturnUrl { get; set; }
        public Bitmap bitmap {get;set;}
    }
}
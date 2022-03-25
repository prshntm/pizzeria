using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class Products
    {
        
            [Key]
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public int ProductPrice { get; set; }
            public string ProductPicture { get; set; }
            public string About { get; set; }
        
    }
}
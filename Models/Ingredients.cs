using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class Ingredients
    {
        [Key]
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public decimal IngredientPrice { get; set; }
        public string IngredientCategory { get; set; }
    }
}
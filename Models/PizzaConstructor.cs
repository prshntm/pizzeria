using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class PizzaConstructor
    {
        private List<PizzaConstructorLine> lineCollection = new List<PizzaConstructorLine>();
        public void AddItem(Ingredients ingredient, int quantity)
        {
            PizzaConstructorLine line = lineCollection
                .Where(g => g.Ingredients.IngredientID == ingredient.IngredientID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new PizzaConstructorLine
                {
                    Ingredients = ingredient,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Ingredients ingredient)
        {
            lineCollection.RemoveAll(l => l.Ingredients.IngredientID == ingredient.IngredientID);
        }

        public decimal ComputeTotalValue()
        {
            return (decimal)(lineCollection.Sum(e => e.Ingredients.IngredientPrice * e.Quantity) + 150);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<PizzaConstructorLine> Lines
        {
            get { return lineCollection; }
        }
    }
    public class PizzaConstructorLine
    { 
        public Ingredients Ingredients { get; set; }
        public int Quantity { get; set; }
    }

}
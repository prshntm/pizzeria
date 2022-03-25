using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class CartLine
    { 
        public Products Products { get; set; }
        public CustomPizza CustomPizza { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
         

        public void AddItem(Products products, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Products.ProductID == products.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Products = products,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void AddPizzaItem(CustomPizza customPizza, Products products, int quantity)
        {

            CartLine line = lineCollection
                .Where(p => p.CustomPizza.PizzaID == customPizza.PizzaID)
                .FirstOrDefault();
            customPizza.ProductID = products.ProductID;
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Products = products,
                    CustomPizza = customPizza,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Products products/*, int quantity*/)
        {
            lineCollection.RemoveAll(l => l.Products.ProductID == products.ProductID);
           /* CartLine line = lineCollection
                .Where(p => p.CustomPizza.PizzaID == products.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Remove(new CartLine
                {
                    Products = products,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity -= quantity;
            }*/
        }
        public void RemovePizzaLine(CustomPizza customPizza, Products products/*, int quantity*/)
        {
            lineCollection.RemoveAll(l => l.CustomPizza.ProductID == customPizza.ProductID);
            /*CartLine line = lineCollection
                .Where(p => p.CustomPizza.PizzaID == customPizza.PizzaID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Remove(new CartLine
                {
                    CustomPizza = customPizza,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity -= quantity;
            }*/
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Products.ProductPrice * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines //обращение к содержимому корзины
        {
            get { return lineCollection; }
        }
    }
}
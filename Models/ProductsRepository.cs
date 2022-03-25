using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPizza.Abstract;

namespace WebPizza.Models
{
    public class ProductsRepository : IRepository //хранилище товаров
    {
        private ProductsContext context = new ProductsContext();
        public IEnumerable<Products> Product
        {
            get { return context.Product; }
        }
        public IEnumerable<Products> List()
        {
            return context.Product;
        }
        public Products Get(int id)
        {
            return context.Product.Find(id);
        }
        public void Save(Products b)
        {
            context.Product.Add(b);
            context.SaveChanges();
        }
    }
}
using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPizza.Abstract;

namespace WebPizza.Models
{
    public class CustomPizzaRepository : IRepositoryCustomPizza, IDisposable
    {
        private ProductsContext context = new ProductsContext();
        public IEnumerable<CustomPizza> CustomPizzas

        {
            get { return context.CustomPizzas; }
        }
        public IEnumerable<CustomPizza> List()
        {
            return context.CustomPizzas;
        }
        public CustomPizza Get(int id)
        {
            return context.CustomPizzas.Find(id);
        }
        public void Save(CustomPizza b)
        {
            context.CustomPizzas.Add(b);
            context.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
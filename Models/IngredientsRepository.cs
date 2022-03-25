using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPizza.Abstract;

namespace WebPizza.Models
{
    public class IngredientsRepository : IRepositoryIngredients, IDisposable
    {
        private IngredientsContext context = new IngredientsContext();
        public IEnumerable<Ingredients> Ingredient
        {
            get { return context.Ingredient; }
        }
        public IEnumerable<Ingredients> List()
        {
            return context.Ingredient;
        }
        public Ingredients Get(int id)
        {
            return context.Ingredient.Find(id);
        }
        public void Save(Ingredients b)
        {
            context.Ingredient.Add(b);
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
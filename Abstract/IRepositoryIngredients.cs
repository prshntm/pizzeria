using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPizza.Abstract
{
    interface IRepositoryIngredients
    {
        void Save(Ingredients b);
        IEnumerable<Ingredients> List();
        Ingredients Get(int id);
    }
}

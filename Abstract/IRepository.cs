using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPizza.Models;

namespace WebPizza.Abstract
{
    public interface IRepository
    {
        void Save(Products b);
        IEnumerable<Products> List();
        Products Get(int id);
    }
}

using WebPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPizza.Abstract
{
    interface IRepositoryCustomPizza
    {
        void Save(CustomPizza b);
        IEnumerable<CustomPizza> List();
        CustomPizza Get(int id);
    }
}

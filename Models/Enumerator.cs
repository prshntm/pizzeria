using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class Enumerator
    {
        public bool MoveNext()
        {
            return false;
        }

        public object Current
        {
            get { return null; }
        }
    }
}
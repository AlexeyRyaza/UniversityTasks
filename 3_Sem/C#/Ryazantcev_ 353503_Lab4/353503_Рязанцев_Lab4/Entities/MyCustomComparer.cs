using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab4.Entities
{
    internal class MyCustomComparer<T> : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return string.Compare(x.Name,  y.Name, StringComparison.Ordinal);
        }
    }
}

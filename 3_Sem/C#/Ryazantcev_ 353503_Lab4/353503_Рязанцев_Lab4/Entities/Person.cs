using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab4.Entities
{
    public class Person
    {
        public string? Name {  get; set; }
        public int FlatNum { get; set; }
        public bool IsOwner { get; set; }

        public Person(string Name, int FlatNum, bool IsOwner) 
        {
            this.Name = Name;
            this.FlatNum = FlatNum; 
            this.IsOwner = IsOwner;
        }
    }
}

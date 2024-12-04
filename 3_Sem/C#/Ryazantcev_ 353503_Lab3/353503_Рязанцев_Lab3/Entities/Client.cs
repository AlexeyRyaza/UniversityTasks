using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab3.Entities
{
    public class Client
    {
        public string? Name {  get; set; }
        
        public Client() { }
        public Client(string name) { Name = name;}
    }
}

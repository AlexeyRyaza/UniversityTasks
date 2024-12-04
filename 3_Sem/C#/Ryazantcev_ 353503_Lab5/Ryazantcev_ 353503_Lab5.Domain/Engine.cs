using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryazantcev__353503_Lab5.Domain
{
    public class Engine
    {
        public string Type { get; set; }  

        public Engine(string type)
        {
            Type = type;
        }

        public Engine() {}

    }
}

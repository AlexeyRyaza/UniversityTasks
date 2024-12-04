using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab3.Entities
{
    public class Call
    {
        string? _clientName;
        string? _rate;
        double _price;
        public Call(string clientName, string rate, double cost)
        {
            _clientName = clientName;
            _rate = rate;

            _price = cost;
        }

        public double GetPrice() { return _price; }
        public string? GetClientname() { return _clientName; }
        public string? GetRatename() { return _rate; }
    }
}

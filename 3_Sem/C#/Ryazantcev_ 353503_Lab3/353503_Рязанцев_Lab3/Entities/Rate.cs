using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab3.Entities
{
    public class Rate
    {
        string? Destination;
        double Cost;

        public Rate(string destination, double cost)
        {
            Destination = destination;
            Cost = cost;
        }

        public void SetDestination(string Destination) {this.Destination = Destination;}
        public void SetCost(double Cost) { this.Cost = Cost;}

        public double GetCost() { return Cost; }
        public string? GetDestination() { return Destination; }
    }
}

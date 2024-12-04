using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab1.Entities
{
    internal class Client : IAdditionOperators<Client, double, double>
    {
        string? Name;
        void SetName(string? NewName)
        {
            Name = NewName;
        }
        public string GetName()
        {
            return Name;
        }
        public Client(string name) 
        {
            this.Name = name;
        }

        double SpentMoney = 0;
        public void MakeCall(double price)
        {
            SpentMoney += price;
        }
        public double GetSpentMoney() { return SpentMoney; }

        public static double operator +(Client left,
                                        double right)
        {
            return left.GetSpentMoney() + right;
        }
    }
}

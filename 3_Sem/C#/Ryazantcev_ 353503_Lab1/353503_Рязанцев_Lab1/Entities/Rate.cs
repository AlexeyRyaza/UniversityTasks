using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab1.Entities
{
    internal class Rate
    {
        public Rate(string name, double cost)
        {
            this.cost = cost;
            this.CityName = name;
        }
        
        double cost;
        string? CityName;
        int NumberOfCalls = 0;

        public void SetCost(double cost) {  this.cost = cost; }
        public double GetCost() { return this.cost; }
        public void SetCityName(string? cityName) { this.CityName = cityName; }
        public string GetCityName() { return this.CityName; }
        public void MakeCall() { NumberOfCalls++; }
        public int GetNumberOfCalls() { return this.NumberOfCalls; }
    }
}

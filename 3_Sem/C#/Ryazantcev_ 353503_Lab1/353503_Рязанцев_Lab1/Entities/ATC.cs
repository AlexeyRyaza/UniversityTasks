using _353503_Рязанцев_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace _353503_Рязанцев_Lab1.Entities
{
    internal class ATC : IMakeCall
    {
        Collections.MyCustomCollection<Client>? Clients = new Collections.MyCustomCollection<Client>();
        Collections.MyCustomCollection<Rate>? Rates = new Collections.MyCustomCollection<Rate>();

        double TotalRevenue = 0;
        int TotalCalls = 0;

        public void MakeCall(string clientName, string rateName)
        {
            Client client = FindClient(clientName);
            Rate rate = FindRate(rateName);
            
            if (client != null && rate != null)
            {                    
                double CostOfCall = rate.GetCost();
                
                client.MakeCall(CostOfCall);
                rate.MakeCall();

                TotalCalls++;
            }
        }

        public void AddRate(string name, double cost)
        {
            Rate NewRate = new(name, cost);
            Rates.Add(NewRate);
        }
        public void AddClient(string name)
        {
            Client NewClient = new(name);
            Clients.Add(NewClient);
        }
        public int GetTotalCalls() { return TotalCalls; }
        public int GetTotalCallsToCity(string CityName)
        {
            for(int i = 0; i < Rates.Count; ++i)
            {
                if (Rates[i].GetCityName().Equals(CityName))
                {
                    return Rates[i].GetNumberOfCalls();
                }
            }
            return 0;
        }
        private Client FindClient(string clientName)
        {
            for (int i = 0; i < Clients.Count; ++i)
            {
                if (Clients[i].GetName().Equals(clientName))
                {
                    return Clients[i];
                }
                
            }
            
            return null;
        }
        private Rate FindRate(string rateName)
        {
            for (int i = 0; i < Rates.Count; ++i)
            {
                if (Rates[i].GetCityName().Equals(rateName))
                {
                    return Rates[i];
                }
            }
           
            return null;
        }
        public double GetTotalRevenueFromClient (string Name)
        {
            for (int i = 0; i < Clients.Count; ++i)
            {
                if (Clients[i].GetName().Equals(Name))
                {
                    return Clients[i].GetSpentMoney();
                }
            }
            return 0;
        }
        public double GetTotalRevenue()
        {
            double total = 0;
            for(int i = 0; i < Clients.Count; i++)
            {
                total = Clients[i] + total;
            }

            return total;
        }
    }
}

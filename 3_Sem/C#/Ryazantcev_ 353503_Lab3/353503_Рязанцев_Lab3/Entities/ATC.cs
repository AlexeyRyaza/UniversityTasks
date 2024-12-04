using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _353503_Рязанцев_Lab3.Entities
{
    public class ATC
    {
        Dictionary<string, Rate> _rates = new();
        List<Client> _clients = new();
        List<Call> _calls = new();

        string _id = new string("0");

        //Client
        public void AddClient(string Name)
        {
            if (Name == null) throw new ArgumentNullException("name");
            Client client = new Client(Name);

            _clients.Add(client);
        }

        public string GetClientSum(string Name)
        {
            if (Name == null) throw new ArgumentNullException("name");

            Client client = new();
            foreach (Client _client in _clients)
            {
                if(_client.Name == Name)
                {
                    client = _client;
                    break;
                }
            }

            if (client.Name == null) { throw new ArgumentNullException("name"); }

            //var GroupedByDest = _calls
            //    .Where(call => call.GetClientname() == client.Name)
            //    .GroupBy(call => call.GetPrice());

            //double t = 0;
            //Call c = new Call("", "", 0);
            //var a = GroupedByDest.GetType();
            ////GroupedByDest.Append(IGrouping < double, Call >);
            //double currPrice = GroupedByDest.First().Key;
            //double total = 0;
            //string? output = "";
            //foreach (var call in GroupedByDest)
            //{
            //    if(currPrice == call.Key)
            //    {
            //        total += call.Key;
            //    }
            //    output += $"\nCalls to {""} with sum: {total}";

            //    currPrice = call.Key;
            //    total = 0;
            //}

            var GroupedByDest = _calls
                .Where(call => call.GetClientname() == client.Name);

            Dictionary<String,Double> Total = new();
            
            foreach (var call in GroupedByDest)
            {
                if (Total.ContainsKey(call.GetRatename()))
                {
                    Total[call.GetRatename()] += call.GetPrice();
                }
                else
                {
                    Total.Add(call.GetRatename(), call.GetPrice());
                }
                
            }

            string output = "";
            foreach (var group in Total) 
            { 
                output += $"{client.Name} made calls to {group.Key} with sum:{group.Value}\n";
            }


            return output;
        }
        //ENDClient

        //RATE
        public void AddRate(string _dest, double _cost)
        {
            Rate rate = new(_dest, _cost);
            _rates.Add(_id, rate);

            int CurId = int.Parse(_id);
            CurId++;
            _id = CurId.ToString();
        }

        public List<Rate?> GetAllRates()
        {
            var AllRates = _rates.Values
                .OrderBy(rate => rate.GetCost())
                .ToList();
            return AllRates;
        }

        //ENDRate

        //CALL
        public void MakeCall(string _clientName, string _rateName)
        {
            if (_clientName == null) throw new ArgumentNullException("name");
            if (_rateName == null) throw new ArgumentNullException("name");

            string _client = "";
            string _rate = "";
            double _cost = 0;

            foreach (Client client in _clients)
            {
                if (client.Name == _clientName)
                {
                    _client = _clientName;
                    break;
                }


            }

            foreach (Rate rate in _rates.Values)
            {
                if (rate.GetDestination() == _rateName)
                {
                    _rate = _rateName;
                    _cost = rate.GetCost();
                    break;
                }


            }

            if ((_client == "") || (_rate == ""))
            {
                return;
            }

            Call call = new(_client, _rate, _cost);

            _calls.Add(call);

        }
        //ENDCALL


        //Revenue
        public int CounterGreaterThan(double checkprice)
        {
            int HigherClients = _clients.Aggregate(0, (acc, client) => 
            acc + (GetTotalClientRevenue(client.Name) > checkprice ? 1 : 0));

            return HigherClients;
        }
        public double getTotalRevenue()
        {
            var AllCalls = _calls
                .Select(call => call)
                .Sum(c=>c.GetPrice());

            //double totalRevenue = 0;

            //foreach (Call call in AllCalls)
            //{
            //    totalRevenue += call.GetPrice();
            //}

            return AllCalls;
        }
        public double GetTotalClientRevenue(string? _clientName)
        {
            var AllClientCalls = _calls.Where(call => call.GetClientname() == _clientName)
                ?.Sum(c=>c.GetPrice())
                ??0;
            //if (!AllClientCalls.Any()) { return 0; }

            //double total = 0;

            //foreach (var call in AllClientCalls)
            //{
            //    total += call.GetPrice();
            //}

            return AllClientCalls;
        }
        public string GetMaxRevenue()
        {
            string name = "";
            double maxprice = 0;

            foreach (var client in _clients)
            {
                double curprice = GetTotalClientRevenue(client.Name);

                if (curprice > maxprice)
                {
                    maxprice = curprice;
                    name = client.Name;
                }
            }
            return name;
            //EndRevenue
        }
    }
}

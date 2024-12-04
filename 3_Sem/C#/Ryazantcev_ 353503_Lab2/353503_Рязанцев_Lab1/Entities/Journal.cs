using _353503_Рязанцев_Lab1.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab1.Entities
{
    internal class Journal
    {
        private Collections.MyCustomCollection<string> _events = new Collections.MyCustomCollection<string>();
        
        public void LogEvent(string eventName)
        {
            _events.Add($"Event: {eventName}");
        }

        public void DisplayEvents()
        {
            foreach (var _event in _events)
            {
                Console.WriteLine(_event);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryazantcev__353503_Lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<Car> DeSerializeByLINQ(string fileName);
        IEnumerable<Car> DeSerializeXML(string fileName);
        IEnumerable<Car> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Car> xxx, string fileName);
        void SerializeXML(IEnumerable<Car> xxx, string fileName);
        void SerializeJSON(IEnumerable<Car> xxx, string fileName);
    }
}

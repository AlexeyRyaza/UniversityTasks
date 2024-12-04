using Ryazantcev__353503_Lab5.Domain;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace SerializerLib
   
{
    public class Serializer : ISerializer
    {
        //Serialization
        public void SerializeByLINQ(IEnumerable<Car> cars, string fileName)
        {
            try
            {
                var root = new XElement("Cars");

                foreach (var car in cars)
                {
                    var carElement = new XElement("Car");

                    foreach (var prop in typeof(Car).GetProperties())
                    {
                        var propValue = prop.GetValue(car);
                        
                        if(propValue is Engine engine)
                        {
                            carElement.Add(new XElement("Engine", engine.Type));
                        }
                        else
                        {
                            carElement.Add(new XElement(prop.Name, propValue?.ToString() ?? ""));
                        }
                    }

                    root.Add(carElement);
                }

                var document = new XDocument(
                    new XDeclaration("1.0","utf-8","yes"), root
                );

                document.Save(fileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error ocurred while LINQ-XML serialization\nError message:" + ex.Message);
            }
        }
        public void SerializeXML(IEnumerable<Car> cars, string fileName)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Car>));

                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, cars);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred while XML serialization\nError message:" + ex.Message);
            }
            
        }
        public void SerializeJSON(IEnumerable<Car> cars, string fileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

                File.WriteAllText(fileName, json);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error ocurred while Json serialization\nError message:" + ex.Message);
            }
        }


        //DeSerialization
        public IEnumerable<Car> DeSerializeXML(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    return (IEnumerable<Car>)serializer.Deserialize(fileStream);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while XML deserialization\nError message: " + ex.Message);
                return Enumerable.Empty<Car>();  
            }
        }
        public IEnumerable<Car> DeSerializeByLINQ(string fileName)
        {
            try
            {
                var doc = XDocument.Load(fileName);
                
                var cars = doc.Descendants("Car")
                              .Select(x => new Car(new Engine(
                                  x.Element("Engine")?.Value
                              )))
                              .ToList(); 

                return cars;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while LINQ-to-XML deserialization\nError message: " + ex.Message);
                return Enumerable.Empty<Car>();
            }
        }
        
        public IEnumerable<Car> DeSerializeJSON(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<Car>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while JSON deserialization\nError message: " + ex.Message);
                return Enumerable.Empty<Car>();
            }          
        }
    }
}

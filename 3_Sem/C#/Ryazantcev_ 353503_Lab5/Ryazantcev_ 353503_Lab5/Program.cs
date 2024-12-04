using Ryazantcev__353503_Lab5.Domain;
using SerializerLib;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Car> cars = new();

//Create 
Car cara = new Car(new Engine("Aafafadf"));
cars.Add(cara);
Car carb = new Car(new Engine("B"));
cars.Add(carb);
Car carc = new Car(new Engine("C"));
cars.Add(carc);
Car card = new Car(new Engine("D"));
cars.Add(card);

//XML
var serializer = new Serializer();

serializer.SerializeXML(cars, "file_1.xml");
serializer.SerializeJSON(cars, "file_2.json");
serializer.SerializeByLINQ(cars, "file_3.xml");

IEnumerable<Car> carsXML = serializer.DeSerializeXML("file_1.xml");
IEnumerable<Car> carsJSON = serializer.DeSerializeJSON("file_2.json");
IEnumerable<Car> carsLINQ = serializer.DeSerializeByLINQ("file_3.xml");

Console.WriteLine("1" + cars[0].Engine.Type);
Console.WriteLine("2" + carsXML.ElementAt<Car>(0).Engine.Type);
Console.WriteLine("3" + carsJSON.ElementAt<Car>(0).Engine.Type); 
Console.WriteLine("4" + carsLINQ.ElementAt<Car>(0).Engine.Type);


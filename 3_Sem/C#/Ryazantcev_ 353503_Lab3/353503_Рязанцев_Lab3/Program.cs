using _353503_Рязанцев_Lab3.Entities;

ATC my_ATC = new();

my_ATC.AddRate("Minsk", 10);
my_ATC.AddRate("Moscow", 200);
my_ATC.AddRate("GOMEL", 100);

List<Rate?> rates = my_ATC.GetAllRates();
foreach(Rate? r in rates)
{
    Console.WriteLine(r.GetDestination());
}

my_ATC.AddClient("Volodya");
my_ATC.AddClient("Vladimir");
my_ATC.AddClient("Vova");

my_ATC.MakeCall("Vova", "Moscow");
my_ATC.MakeCall("Volodya", "Minsk");
my_ATC.MakeCall("Volodya", "asdsad");
my_ATC.MakeCall("Volodya", "GOMEL");
my_ATC.MakeCall("Volodya", "GOMEL");


Console.WriteLine("\n" + my_ATC.getTotalRevenue());

Console.WriteLine("\n" + my_ATC.GetTotalClientRevenue("Volodya"));
Console.WriteLine(my_ATC.GetTotalClientRevenue("Vova"));
Console.WriteLine(my_ATC.GetTotalClientRevenue("Vladimir"));

Console.WriteLine("\n" + my_ATC.GetMaxRevenue());

Console.WriteLine("\n" + my_ATC.CounterGreaterThan(100));

Console.WriteLine("\n" + my_ATC.GetClientSum("Volodya"));
using _353503_Рязанцев_Lab1.Entities;

_353503_Рязанцев_Lab1.Entities.ATC my_ATC = new();
_353503_Рязанцев_Lab1.Entities.Journal journal = new();

my_ATC.RateListChanged += journal.LogEvent;
my_ATC.ClientListChanged += journal.LogEvent;

//my_ATC.ClientListChanged += message => Console.WriteLine(message); // Лямбда-выражение для вывода сообщения в консоль.
//my_ATC.RateListChanged += message => Console.WriteLine(message);

my_ATC.CallMade += message => Console.WriteLine(message);

Console.WriteLine(my_ATC.GetTotalRevenue().ToString());

my_ATC.AddClient("Vladimir");
my_ATC.AddClient("Vova");

my_ATC.AddRate("Minsk", 10);
my_ATC.AddRate("Moscow", 20);

my_ATC.MakeCall("Vova", "Moscow");
my_ATC.MakeCall("Vlva", "Moscow"); 
my_ATC.MakeCall("Vova", "Minsk");
my_ATC.MakeCall("Vladimir", "Minsk");

Console.WriteLine(my_ATC.GetTotalRevenueFromClient("Vova").ToString());
Console.WriteLine(my_ATC.GetTotalRevenueFromClient("Vladimir").ToString());

Console.WriteLine(my_ATC.GetTotalRevenue());

journal.DisplayEvents();

try{
    my_ATC.DemonstrateExeption();

}catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}

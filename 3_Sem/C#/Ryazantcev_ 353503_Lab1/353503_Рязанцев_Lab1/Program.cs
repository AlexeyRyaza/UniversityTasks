_353503_Рязанцев_Lab1.Entities.ATC my_ATC = new();

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
Console.WriteLine(my_ATC.GetTotalCallsToCity("Minskl"));
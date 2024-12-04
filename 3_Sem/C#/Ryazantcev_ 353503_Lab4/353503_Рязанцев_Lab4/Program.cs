// See https://aka.ms/new-console-template for more information
using _353503_Рязанцев_Lab4.Entities;
using _353503_Рязанцев_Lab4.Services;
using System.Globalization;
List<Person> House = new();

string? folderName = "Ryazantcev_Lab4";
if (Directory.Exists(folderName))
{
    Directory.Delete(folderName, true);
    Console.WriteLine("Folder Deleted");
}
Directory.CreateDirectory(folderName);

List<string> extensions = new() { ".txt", ".rtf", ".dat", ".inf"};
var random = new Random();
for(int i = 0; i < 10; i++)
{
    string fileName = Path.Combine(folderName, 
        Path.GetRandomFileName() + extensions[random.Next(extensions.Count)]);
    File.Create(fileName).Close();
}

foreach(var file in Directory.GetFiles(folderName))
{
    Console.WriteLine($"File: {Path.GetFileNameWithoutExtension(file)} " +
        $"has an extension {Path.GetExtension(file)}");
}

House.Add(new Person("ZVova", 81, true));
House.Add(new Person("AVolodya", 20, true));
House.Add(new Person("YVladimir", 44, true));
House.Add(new Person("BVovchik", 40, false));
House.Add(new Person("JVovan", 57, false));

var fileService = new FileService<Person>();
string SaveFile = Path.Combine(folderName, "HouseInfo.bin");
fileService.SaveData(House, SaveFile);

string newFileName = Path.Combine(folderName, "VovinDom.bin");
if (File.Exists(newFileName))
{
    File.Delete(newFileName);
}
File.Move(SaveFile, newFileName);

var LoadPeopleInfo =  fileService.ReadFile(newFileName).ToList();
Console.WriteLine("\nUnsorted Collection:");
foreach(var person in LoadPeopleInfo)
{
    Console.WriteLine($"Name: {person.Name} Flat: {person.FlatNum} IsOwner: {person.IsOwner}"); 
}

var SortedPeoplebtName = LoadPeopleInfo.OrderBy(p => p, new MyCustomComparer<Person>()).ToList();
Console.WriteLine("\nSorted Collection by Name:");
foreach(var person in SortedPeoplebtName)
{
    Console.WriteLine($"Name: {person.Name} Flat: {person.FlatNum} IsOwner: {person.IsOwner}");
}

var SortedPeoplebyNum = LoadPeopleInfo.OrderBy(p => p.FlatNum); 
Console.WriteLine("\nSorted Collectionby number:");
foreach (var person in SortedPeoplebyNum)
{
    Console.WriteLine($"Name: {person.Name} Flat: {person.FlatNum} IsOwner: {person.IsOwner}");
}
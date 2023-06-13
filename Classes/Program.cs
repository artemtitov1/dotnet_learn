using Classes.Building;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

string factoryDirName = "Data\\Factories.txt";
string unitDirName = "Data\\Units.txt";
string tankDirName = "Data\\Tanks.txt";


string facPath = Path.Combine(projectDirectory, factoryDirName);
string unitPath = Path.Combine(projectDirectory, unitDirName);
string tankPath = Path.Combine(projectDirectory, tankDirName);


Factory factory = new();
Unit unit = new();
Tank tank = new();

var factories = factory.Read(facPath);
var units = unit.Read(unitPath);
var tanks = tank.Read(tankPath);

void printTanks()
{
    var query = from t in tanks
                join u in units on t.UnitId equals u.Id
                join f in factories on u.FactoryId equals f.Id
                select new
                {
                    TankName = t.Name,
                    UnitName = u.Name,
                    FactoryName = f.Name
                };
    foreach (var result in query)
    {
        Console.WriteLine($"Резервуар:\t{result.TankName}\tУстановка\t{result.UnitName}, Фабрика\t{result.FactoryName}");
    }
}

printTanks();

void printTotalVolume()
{
    var query = (from t in tanks
                select t).Sum(t => t.Volume);
    Console.WriteLine($"Общий занятый объем: {query}");
}

printTotalVolume();

void findFactoryByName()
{
    Console.Write("Поиск фабрики по названию.\n" +
        "Введите название фабрики: ");
    string name = Console.ReadLine();
    var query = from f in factories
                where f.Name == name
                select f.Id;
    if (query.Any())
    {
        Console.WriteLine($"Id найденной фабрики: {query.First()}");
    }
    else
    {
        Console.WriteLine("Фабрика с данным названием не найдена");
    }
}

findFactoryByName();

void ConvertFactoriesJson()
{
    var encoderSettings = new TextEncoderSettings();
    encoderSettings.AllowCharacters('\u2116');
    encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
    encoderSettings.AllowRange(UnicodeRanges.Cyrillic);

    var options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(encoderSettings),
        WriteIndented = true
    };
    string factoriesJson = JsonSerializer.Serialize(factories, options);
    Console.WriteLine(factoriesJson);
}

ConvertFactoriesJson();
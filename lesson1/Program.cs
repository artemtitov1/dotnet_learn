using lesson1;
using System.Text.Json;

string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
string dataPath = "\\Data\\JSON_sample_1.json";
string fullPath = projectPath + dataPath;
Console.WriteLine(fullPath);

string ReadJson(string path)
{
    StreamReader sr = new StreamReader(path);
    string json = sr.ReadToEnd();
    return json;
}

var deals = JsonSerializer.Deserialize<List<Deal>>(ReadJson(fullPath));
//foreach (var deal in deals)
//{
//    Console.WriteLine(deal.Id);
//}

DealExtension d = new DealExtension();

var totalDeals = d.GetNumberOfDeals(deals);
foreach (var deal in totalDeals)
    Console.WriteLine(deal);

var sumByMonths = d.GetSumByMonths(deals);
foreach (var month in sumByMonths)
    Console.WriteLine(month);
using System.Text.Json;

var json = File.ReadAllText("pages.json");
var root = JsonSerializer.Deserialize<Rootobject>(json);

Page lowestVisitorPage = null;
Page highestVisitorPage = null;
var allVisitors = 0;

foreach (var page in root.Pages)
    VisitPage(page);

Console.WriteLine($"Összes látogatók száma: {allVisitors}");

void VisitPage(Page page, string path = "")
{
    allVisitors += page.Visitor;

    if (string.IsNullOrWhiteSpace(path))
        path = $"{page.Name}";
    else
        path = $"{path} -> {page.Name}";
    
    Console.WriteLine($"{path} látogató szám: {page.Visitor}");
    
    if (page.Pages.Any())
    {
        Console.WriteLine("Talált aloldalak:");

        foreach (var subPage in page.Pages)
            VisitPage(subPage, path);
    }
    else
        Console.WriteLine("Nincsenek aloldalak");
}
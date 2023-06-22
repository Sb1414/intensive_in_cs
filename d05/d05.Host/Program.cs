// See https://aka.ms/new-console-template for more information

using d05.Nasa;
using d05.Nasa.Apod;
using d05.Nasa.Apod.Models;
using d05.Nasa.Earth;
using d05.Nasa.Earth.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string currentDirectory = Directory.GetCurrentDirectory();
string appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder
    .AddJsonFile(appSettingsPath);
var configuration = configurationBuilder.Build();

if (args[0] == "apod")
{
    if (!int.TryParse(args[1], out int n)) n = 0;
    INasaClient<int, Task<MediaOfToday[]>> ad_astra = new ApodClient(configuration["ApiKey"]);
    var result = await ad_astra.GetAsync(n);
    foreach (var mediaOfToday in result)
    {
        Console.WriteLine($"{mediaOfToday.ToString()}");
    }
} else if (args[0] == "earth")
{
    INasaClient<EarthRequest, Task<MediaOfTodayEarth[]>> ad_astra = new EarthClient(configuration["ApiKey"]);
    EarthRequest request = new EarthRequest
    {
        Latitude = "29.78", Longitude = "-95.33", Date = DateTime.Parse("2018-01-01"), Dimensions = "0.10"
    };

    var result = await ad_astra.GetAsync(request);
    if (result != null && result.Length > 0)
    {
        foreach (var mediaOfToday in result)
        {
            Console.WriteLine(mediaOfToday.ToString());
        }
    }
    else
    {
        Console.WriteLine("No results found.");
    }
}
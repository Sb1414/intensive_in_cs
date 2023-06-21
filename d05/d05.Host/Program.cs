// See https://aka.ms/new-console-template for more information

using d05.Nasa;
using d05.Nasa.Apod;
using d05.Nasa.Apod.Models;
using Microsoft.Extensions.Configuration;

// if (args.Length < 2)
// {
//     Console.WriteLine("Usage: dotnet run <apiKey> <count>");
//     return;
// }
//
// string apiKey = args[0];
// int count = int.Parse(args[1]);
//
// var apodClient = new ApodClient(apiKey);
// var mediaOfTodayArray = await apodClient.GetAsync(count);
//
// if (mediaOfTodayArray != null)
// {
//     foreach (var mediaOfToday in mediaOfTodayArray)
//     {
//         Console.WriteLine($"{mediaOfToday.Date}\n'{mediaOfToday.Title}' by {mediaOfToday.Copyright}");
//         Console.WriteLine(mediaOfToday.Explanation);
//         Console.WriteLine(mediaOfToday.Url);
//         Console.WriteLine();
//     }
// }
// else
// {
//     Console.WriteLine("Failed to retrieve data from NASA API.");
// }

if (args.Length < 2)
{
    Console.WriteLine("Usage: dotnet run <apiKey> <count>");
    return;
}

string apiKey = args[0];
int count = int.Parse(args[1]);

var apodClient = new ApodClient(apiKey);
var mediaOfTodayArray = await apodClient.GetAsync(count);

if (mediaOfTodayArray != null)
{
    foreach (var mediaOfToday in mediaOfTodayArray)
    {
        // Console.WriteLine($"{mediaOfToday.Date}\n'{mediaOfToday.Title}' by {mediaOfToday.Copyright}");
        // Console.WriteLine(mediaOfToday.Explanation);
        // Console.WriteLine(mediaOfToday.Url);
        // Console.WriteLine();
        Console.WriteLine(mediaOfToday.ToString());
    }
}
else
{
    Console.WriteLine("Failed to retrieve data from NASA API.");
}

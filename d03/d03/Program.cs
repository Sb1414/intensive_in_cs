// See https://aka.ms/new-console-template for more information

using d03.Configuration;
using d03.Sources;

if (args.Length < 1)
{
    Console.WriteLine("Путь к файлу не указан.");
    return;
}

string filePath = args[0];
var jsonSource = new JsonSource(filePath);
var configuration = new Configuration(jsonSource);

Console.WriteLine("Configuration");
foreach (var param in configuration.Params)
{
    Console.WriteLine($"{param.Key}: {param.Value}");
}
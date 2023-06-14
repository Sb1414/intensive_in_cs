// See https://aka.ms/new-console-template for more information

using d03.Configuration;
using d03.Sources;
/*
if (args.Length < 1)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

string filePath = args[0];
string extension = Path.GetExtension(filePath);

IConfigurationSource source;
if (extension.Equals(".json", StringComparison.OrdinalIgnoreCase))
{
    source = new JsonSource(filePath);
}
else if (extension.Equals(".yml", StringComparison.OrdinalIgnoreCase) || extension.Equals(".yaml", StringComparison.OrdinalIgnoreCase))
{
    source = new YamlSource(filePath);
}
else
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

var configuration = new Configuration(source);

if (configuration != null)
{
    int i = 0;
    foreach (var parameter in configuration.Params)
    {
        if (i == 0)
            Console.WriteLine("Configuration");
        Console.WriteLine($"{parameter.Key}: {parameter.Value}");
        i++;
    }
}
*/

if (args.Length != 4)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

string jsonPath = args[0];
int jsonPriority = int.Parse(args[1]);
string yamlPath = args[2];
int yamlPriority = int.Parse(args[3]);

var jsonSource = new JsonSource(jsonPath, jsonPriority);
var yamlSource = new YamlSource(yamlPath, yamlPriority);

var configuration = new Configuration(jsonSource, yamlSource);

Console.WriteLine("Configuration");
foreach (var parameter in configuration.Params)
{
    Console.WriteLine($"{parameter.Key}: {parameter.Value}");
}
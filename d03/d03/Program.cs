// See https://aka.ms/new-console-template for more information

using d03.Configuration;
using d03.Sources;

if (args.Length < 1)
{
    Console.WriteLine("Путь к файлу не указан.");
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
    Console.WriteLine("Неподдерживаемый формат файла.");
    return;
}

var configuration = new Configuration(source);

Console.WriteLine("Configuration");
foreach (var parameter in configuration.Params)
{
    Console.WriteLine($"{parameter.Key}: {parameter.Value}");
}
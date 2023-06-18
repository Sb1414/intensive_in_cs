// See https://aka.ms/new-console-template for more information

using d03_ex04;
using d03_ex04.Sources;

if (args.Length != 4)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

List<IConfigurationSource> sources = new List<IConfigurationSource>();

for (int i = 0; i < args.Length; i += 2)
{
    string filePath = args[i];
    int priority = int.Parse(args[i + 1]);
    string extension = Path.GetExtension(filePath);

    IConfigurationSource source;
    if (extension.Equals(".json", StringComparison.OrdinalIgnoreCase))
    {
        source = new JsonSource(filePath, priority);
    }
    else if (extension.Equals(".yml", StringComparison.OrdinalIgnoreCase) || extension.Equals(".yaml", StringComparison.OrdinalIgnoreCase))
    {
        source = new YamlSource(filePath, priority);
    }
    else
    {
        Console.WriteLine("Invalid data. Check your input and try again.");
        return;
    }

    sources.Add(source);
}

var configuration = new Configuration(sources);

if (configuration.Params != null)
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

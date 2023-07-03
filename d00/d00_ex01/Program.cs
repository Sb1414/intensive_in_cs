// See https://aka.ms/new-console-template for more information

using System.Reflection;

try
{
    string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 39);
    // string filePath = Path.Combine(currentDirectory, @"materials\us_names.txt"); // для винды
    string filePath = Path.Combine(currentDirectory, @"materials/us_names.txt"); // для мака
    Console.WriteLine(currentDirectory + "\n" + filePath);

    string[] names = LoadNamesFromFile(filePath); // Загрузка списка имен из файла

    Console.WriteLine("Enter name:");
    string userInput = Console.ReadLine();

    string foundName = FindName(userInput, names);

    if (foundName != null)
    {
        Console.WriteLine($"Hi, {foundName}!");
    }
    else
    {
        OfferCorrectedName(userInput, names);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}

static void OfferCorrectedName(string userInput, string[] names)
{
    string[] correctedNames = FindClosestNames(userInput, names);

    if (correctedNames != null && correctedNames.Length > 0)
    {
        for (int i = 0; i < correctedNames.Length; i++)
        {
            Console.WriteLine($"Did you mean \"{correctedNames[i]}\"? Yes/No");
            string answer = Console.ReadLine();

            if (answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Hi, {correctedNames[i]}!");
                return;
            }
            else if (answer.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                if (i == correctedNames.Length - 1)
                {
                    Console.WriteLine("Your name was not found.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Something went wrong. Check your input and retry.");
                i--;
            }
        }
    }
    else
    {
        Console.WriteLine("Your name was not found.");
    }
}

static string[] LoadNamesFromFile(string filename)
{
    try
    {
        // Чтение файла и возврат списка имен
        return File.ReadAllLines(filename);
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine(filename);
        Console.WriteLine("Файл со списком имен не найден.");
        return new string[0];
    }
    catch (Exception)
    {
        Console.WriteLine("Ошибка при загрузке списка имен.");
        return new string[0];
    }
}

static string FindName(string input, string[] names)
{
    foreach (string name in names)
    {
        if (name.Equals(input, StringComparison.OrdinalIgnoreCase))
        {
            return name;
        }
    }

    return null;
}

static string[] FindClosestNames(string input, string[] names)
{
    List<string> closestNames = new List<string>();

    foreach (string name in names)
    {
        int distance = ComputeLevenshteinDistance(input, name);
        if (distance < 2)
        {
            closestNames.Add(name);
        }
    }

    if (closestNames.Count > 0)
    {
        return closestNames.ToArray();
    }

    return null;
}


static int ComputeLevenshteinDistance(string source, string target)
{
    int[,] distance = new int[source.Length + 1, target.Length + 1];

    for (int i = 0; i <= source.Length; i++)
    {
        distance[i, 0] = i;
    }

    for (int j = 0; j <= target.Length; j++)
    {
        distance[0, j] = j;
    }

    for (int i = 1; i <= source.Length; i++)
    {
        for (int j = 1; j <= target.Length; j++)
        {
            int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;

            distance[i, j] = Math.Min(
                Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                distance[i - 1, j - 1] + cost
            );
        }
    }

    return distance[source.Length, target.Length];
}

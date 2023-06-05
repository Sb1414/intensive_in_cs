// See https://aka.ms/new-console-template for more information

using System.Reflection;

try
{
    string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    // Удаление последних 16 символов из строки filePath
    currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 16);

    string filePath = Path.Combine(currentDirectory, @"names.txt");


    // Загрузка списка имен из файла
    string[] names = LoadNamesFromFile(filePath);

    // Запрашиваем имя пользователя
    Console.WriteLine("Enter name:");
    string userInput = Console.ReadLine();

    string foundName = FindExactName(userInput, names);
    if (foundName != null)
    {
        // Имя найдено в словаре
        Console.WriteLine($"Hi, {foundName}!");
    }
    else
    {
        string correctedName = FindClosestName(userInput, names);
        if (correctedName != null)
        {
            // Предложение исправленного имени
            Console.WriteLine($"Did you mean \"{correctedName}\"? Yes/No");
            string answer = Console.ReadLine();

            if (answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                // Исправленное имя принято
                Console.WriteLine($"Hi, {correctedName}!");
            }
            else if (answer.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Your name was not found.");
            }
            else
            {
                Console.WriteLine("Your name was not found.");
            }
        }
        else
        {
            // Имя не найдено
            Console.WriteLine("Your name was not found.");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}");
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

static string FindExactName(string input, string[] names)
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

static string FindClosestName(string input, string[] names)
{
    string closestName = null;
    int minDistance = int.MaxValue;

    foreach (string name in names)
    {
        int distance = ComputeLevenshteinDistance(input, name);
        if (distance < minDistance)
        {
            minDistance = distance;
            closestName = name;
        }
    }

    if (minDistance < 2)
    {
        return closestName;
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
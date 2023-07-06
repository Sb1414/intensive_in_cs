using d04.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;
using System.Text.Json;

string currentDirectory = Directory.GetCurrentDirectory();
string appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

Console.WriteLine(appSettingsPath + " <===");

IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true)
        .Build();

// Получение путей к файлам из конфигурации
string bookReviewsFilePath = configuration.GetSection("BookReviews").Value;
string movieReviewsFilePath = configuration.GetSection("MovieReviews").Value;


if (args.Length > 0 && args[0] == "best")
{
    draw();
    exBest();
    draw();
}
else
{

    bool fl = true;
    while (fl)
    {
        menu();
        string input = Console.ReadLine();
        int num;
        if (int.TryParse(input, out num))
        {
            switch (num)
            {
                case 0:
                    draw();
                    ex00();
                    print_ex00();
                    draw();
                    break;
                case 1:
                    draw();
                    ex01();
                    print_ex01();
                    draw();
                    break;
                case 2:
                    draw();
                    ex02();
                    draw();
                    break;
                default:
                    fl = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
        }
    }
}

BookReview[] bookReviews;
RootObjectMovieReview data;

void ex00()
{
    string json = File.ReadAllText(bookReviewsFilePath);

    // Десериализация JSON в объекты
    RootObjectBookReview data_ = JsonSerializer.Deserialize<RootObjectBookReview>(json);

    // Создание списка объектов BookReview из данных JSON
    bookReviews = new BookReview[data_.Results.Length];
    for (int i = 0; i < data_.Results.Length; i++)
    {
        BookResult result = data_.Results[i];
        BookDetail bookDetail = result.BookDetails[0];

        BookReview bookReview = new BookReview
        {
            Title = bookDetail.Title,
            Author = bookDetail.Author,
            Rank = result.Rank,
            ListName = result.ListName,
            SummaryShort = bookDetail.Description,
            Url = result.AmazonProductUrl
        };

        bookReviews[i] = bookReview;
    }
}

void print_ex00()
{
    foreach (BookReview bookReview in bookReviews)
    {
        Console.WriteLine(bookReview.ToString() + "\n");
    }
}

void ex01()
{
    string json = File.ReadAllText(movieReviewsFilePath);

    // Десериализация JSON в объекты
    data = JsonSerializer.Deserialize<RootObjectMovieReview>(json);
}

void print_ex01()
{
    // Вывод списка фильмов в консоль
    foreach (MovieReview movie in data.Results)
    {
        Console.WriteLine(movie.ToString() + "\n");
    }
}

void ex02()
{
    ex00();
    ex01();
    Console.WriteLine("Input search text:");
    string searchText = Console.ReadLine();

    // Поиск фильмов по заголовку
    MovieReview[] movieSearchResult = data.Results.Search(searchText);

    // Поиск книг по заголовку
    BookReview[] bookSearchResult = bookReviews.Search(searchText);

    // Объединение результатов поиска книг и фильмов
    var combinedResults = movieSearchResult.Cast<ISearchable>()
        .Concat(bookSearchResult.Cast<ISearchable>());

    // Преобразование в массив результатов
    ISearchable[] searchResult = combinedResults.ToArray();

    if (searchResult.Length == 0)
    {
        Console.WriteLine($"There are no \"{searchText}” in media today.");
    }
    else
    {
        Console.WriteLine($"\nItems found: {searchResult.Length}\n");

        // Группировка результатов по типу (фильм/книга)
        var groupedResults = searchResult.GroupBy(item => item.GetType().Name)
            .Select(group => new { Type = group.Key, Results = group.OrderBy(item => item.Title) });

        foreach (var group in groupedResults)
        {
            Console.WriteLine($"{group.Type} search result [{group.Results.Count()}]:");
            foreach (var item in group.Results)
            {
                Console.WriteLine($"- {item.Title}");
                Console.WriteLine($"{item}");
                Console.WriteLine();
            }
        }
    }
}

void exBest()
{
    ex00();
    ex01();
    BookReview bestBook;
    MovieReview bestMovieReview;
    
    bestBook = bookReviews.FirstOrDefault();

    bestMovieReview = data.Results.FirstOrDefault(movie => movie.CriticsPick == 1);

    Console.WriteLine("Best in books:");
    Console.WriteLine($"- {bestBook}");
    Console.WriteLine();

    Console.WriteLine("Best in movie reviews:");
    Console.WriteLine($"- {bestMovieReview}");
    Console.WriteLine();
}


void menu()
{
    Console.WriteLine("Введите номер задания\n");
    Console.WriteLine("0. ex00");
    Console.WriteLine("1. ex01");
    Console.WriteLine("2. ex02");
}

void draw()
{
    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
}
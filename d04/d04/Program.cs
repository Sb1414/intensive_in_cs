using d04.Model;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;
using System.Text.Json;

string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

string currentDirectory2 = currentDirectory.Substring(0, currentDirectory.Length - 16);

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
                draw();
                break;
            case 1:
                draw();
                ex01();
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

void ex00()
{
    string filePath = currentDirectory2 + "book_reviews.json"; // для винды
    // string filePath = "book_reviews.json"; // для мака

    string json = File.ReadAllText(filePath);

    // Десериализация JSON в объекты
    RootObjectBookReview data = JsonSerializer.Deserialize<RootObjectBookReview>(json);

    // Создание списка объектов BookReview из данных JSON
    BookReview[] bookReviews = new BookReview[data.Results.Length];
    for (int i = 0; i < data.Results.Length; i++)
    {
        BookResult result = data.Results[i];
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

    foreach (BookReview bookReview in bookReviews)
    {
        Console.WriteLine(bookReview.ToString() + "\n");
    }
}

void ex01()
{
    string filePath = currentDirectory2 + "movie_reviews.json"; // для винды
    // string filePath = "book_reviews.json"; // для мака

    string json = File.ReadAllText(filePath);

    // Десериализация JSON в объекты
    RootObjectMovieReview data = JsonSerializer.Deserialize<RootObjectMovieReview>(json);

    // Вывод списка фильмов в консоль
    foreach (MovieReview movie in data.Results)
    {
        Console.WriteLine(movie.ToString() + "\n");
    }
}

void menu()
{
    Console.WriteLine("Введите номер задания\n");
    Console.WriteLine("0. ex00");
    Console.WriteLine("1. ex01");
    Console.WriteLine("2. ex02");
    Console.WriteLine("3. ex03");
}

void draw()
{
    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
}
using d04.Model;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;
using System.Text.Json;

string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

string currentDirectory2 = currentDirectory.Substring(0, currentDirectory.Length - 16);
string filePath = currentDirectory2 + "book_reviews.json"; // для винды
// string filePath = "book_reviews.json"; // для мака

string json = File.ReadAllText(filePath);

// Десериализация JSON в объекты
RootObject data = JsonSerializer.Deserialize<RootObject>(json);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d04.Model
{

    public class BookReview : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("list_name")]
        public string ListName { get; set; }

        [JsonPropertyName("summary_short")]
        public string SummaryShort { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author} [{Rank} on NYT’s {ListName}]\n{SummaryShort}\n{Url}";
        }

        string ISearchable.Title => Title;
    }

    public class RootObjectBookReview
    {
        [JsonPropertyName("results")]
        public BookResult[] Results { get; set; }
    }

    public class BookResult
    {
        [JsonPropertyName("list_name")]
        public string ListName { get; set; }

        [JsonPropertyName("book_details")]
        public BookDetail[] BookDetails { get; set; }

        [JsonPropertyName("amazon_product_url")]
        public string AmazonProductUrl { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }
    }

    public class BookDetail
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}

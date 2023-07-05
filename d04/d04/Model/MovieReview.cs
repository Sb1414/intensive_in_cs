using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d04.Model
{
    public class MovieReview : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("critics_pick")]
        public int CriticsPick { get; set; }

        [JsonPropertyName("summary_short")]
        public string SummaryShort { get; set; }

        [JsonPropertyName("link")]
        public ReviewLink Link { get; set; }

        public override string ToString()
        {
            return $"{Title} {(CriticsPick == 1 ? "[NYT critic’s pick]" : "")}\n{SummaryShort}\n{Link.Url}";
        }

        string ISearchable.Title => Title;
    }

    public class ReviewLink
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class RootObjectMovieReview
    {
        [JsonPropertyName("results")]
        public List<MovieReview> Results { get; set; }
    }
}

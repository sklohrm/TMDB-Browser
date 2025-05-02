namespace TMDBBrowser.Models;
using System.Text.Json.Serialization;


public class MovieSearchResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<Movie>? Results { get; set; }
}

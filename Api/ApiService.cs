using System.Net;
using System.Text.Json;
using TMDBBrowser.Models;

namespace TMDBBrowser.Api;

public class ApiService
{
    public static async Task<List<Movie>> SearchMovie(string title)
    {
        try
        {
            string encodedTitle = WebUtility.UrlEncode(title);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/search/movie?query={encodedTitle}&include_adult=false&language=en-US&page=1"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", $"Bearer {GlobalSettings.ApiReadAccessToken}" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var movieResponse = JsonSerializer.Deserialize<MovieSearchResponse>(body);
            return movieResponse?.Results ?? new List<Movie>();

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"HTTP request failed: {e.Message}");
            return new List<Movie>();
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Error deserializing the response: {e.Message}");
            return new List<Movie>();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            return new List<Movie>();
        }
    }

    public static async Task<MovieDetail?> GetMovieDetails(string movie_id)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movie_id}?language=en-US"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", $"Bearer {GlobalSettings.ApiReadAccessToken}" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var movieDetailResponse = JsonSerializer.Deserialize<MovieDetail>(body);
            return movieDetailResponse;


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"HTTP request failed: {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Error deserializing the response: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        return null;
    }
}

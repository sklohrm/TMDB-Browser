namespace TMDBBrowser.Views;

using TMDBBrowser.Models;
using TMDBBrowser.Api;

public class SearchMenu : IMenu
{
    public void Display()
    {
        Console.WriteLine("========Search========");
        Console.WriteLine("1. Search Movies");
        Console.WriteLine("2. Search TV Shows");
        Console.WriteLine("3. Search People");
        Console.WriteLine("4. Search Companies");
        Console.WriteLine("5. Search Collections");
        Console.WriteLine("6. Search Keywords");
        Console.WriteLine("0. Go Back");
        Console.WriteLine("======================");

        Console.Write("Select an Option: ");
    }

    public IMenu? HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                var movieList = searchMovie().Result;
                return new SearchResultsMenu<Movie>(movieList);
            case "2":
                searchMovie();
                return null;
            case "3":
                searchMovie();
                return null;
            case "4":
                searchMovie();
                return null;
            case "5":
                searchMovie();
                return null;
            case "6":
                searchMovie();
                return null;
            case "0":
                return null;
            default:
                Console.WriteLine("Invalid input.");
                return this;

        }
    }

    private async Task<List<Movie>> searchMovie()
    {
        Console.WriteLine("Enter the name a movie to search:");
        string input = Console.ReadLine() ?? String.Empty;
        List<Movie> movies = await ApiService.SearchMovie(input);
        return movies;
    }

}

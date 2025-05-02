namespace TMDBBrowser.Views;

using TMDBBrowser.Factories;
using TMDBBrowser.Models;

public class SearchResultsMenu<T> : IMenu where T : IDisplayable
{
    private readonly List<T> _results;

    public SearchResultsMenu(List<T> results)
    {
        _results = results;
    }

    public void Display()
    {
        Console.WriteLine("\tSearch Results");
        DisplayList();
        Console.WriteLine("Choose a command: ");
        Console.WriteLine("1. View Details");
        Console.WriteLine("0. Go Back");
    }

    public IMenu? HandleInput(string input)
    {
        int parsedInput;
        while (!int.TryParse(input, out parsedInput) || parsedInput > _results.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
            input = Console.ReadLine() ?? String.Empty;
        }

        if (parsedInput == 0) {
            return null;
        } else {
            return DetailMenuFactory.CreateDetailMenuFor(_results[parsedInput - 1]);
        }
    }

    private void DisplayList()
    {
        for (int i = 0; i < _results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_results[i].Display()}");
        }
    }

}

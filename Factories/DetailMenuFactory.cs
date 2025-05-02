namespace TMDBBrowser.Factories;

using TMDBBrowser.Models;
using TMDBBrowser.Views;



public class DetailMenuFactory
{
    public static IMenu CreateDetailMenuFor(IDisplayable model)
    {
        switch (model)
        {
            case Movie:
                return null;
            default:
                return null;


        }
    }
}

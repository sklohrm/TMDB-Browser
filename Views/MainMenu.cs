namespace TMDBBrowser.Views;

public class MainMenu : IMenu
{
    public void Display()
    {
        Console.WriteLine("\tMain Menu");
        Console.WriteLine("Choose a command: ");
        Console.WriteLine("1. Search");
        Console.WriteLine("0. Exit Application");
    }

    public IMenu? HandleInput(string input)
    {
        switch (input) {
            case "1":
                return new SearchMenu();
            default:
                return null;
        }
    }


}

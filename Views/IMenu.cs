namespace TMDBBrowser.Views;

public interface IMenu
{
    void Display();
    IMenu? HandleInput(string input);
}

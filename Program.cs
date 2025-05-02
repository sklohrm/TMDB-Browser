// See https://aka.ms/new-console-template for more information
using TMDBBrowser.Views;

class Program
{
    static void Main(string[] args)
    {

        var navigationStack = new Stack<IMenu>();
        navigationStack.Push(new MainMenu());

        while (navigationStack.Count > 0)
        {

            Console.Clear();

            var currentView = navigationStack.Peek();

            currentView.Display();

            var input = Console.ReadLine() ?? String.Empty;
            var nextView = currentView.HandleInput(input);

            if (nextView == null)
            {
                navigationStack.Pop();
            }
            else if (nextView != currentView)
            {
                navigationStack.Push(nextView);
            }
        }
    }
}

namespace MooGame.View;


public class ConsoleUI : IUI
{

    public string GetPlayerUsername()
    {
        string userName = string.Empty;

        userName = Console.ReadLine();

        if (userName == "")
        {
            userName = "Unknown player";
        }

        return userName;
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }


    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public void PrintMenu()
    {
        throw new NotImplementedException();
    }

}

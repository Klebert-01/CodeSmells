namespace MooGame.View;


public class ConsoleIO : IUserInterface
{

    public string GetPlayerUsername()
    {
        string userName = string.Empty;

        userName = Console.ReadLine();

        if (userName == null)
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
    public void Exit()
    {
        Environment.Exit(0);
    }
}

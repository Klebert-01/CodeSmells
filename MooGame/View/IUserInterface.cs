namespace MooGame.View;

public interface IUserInterface
{
    string GetPlayerUsername();
    public string GetInput();
    public void Print(string text);
    public void Exit();
    public void PrintMenu();

}

namespace MooGame.View;

public interface IUI
{
    string GetPlayerUsername();
    public string GetInput();
    public void Print(string text);
    public void Exit();
    public void PrintMenu();

}

namespace MooGame.GameLogic;

public interface IMooGameLogic
{
    bool TogglePracticeRun();
    string GetNumberOfBullsAndCows(string goal, string guess);
    string CreateRandomNumber();
    bool ToggleGameOn();
}
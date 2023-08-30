namespace MooGame.GameLogic;

public interface IMooGameLogic
{
    bool TogglePracticeRun();
    string CheckPlayerGuess(string goal, string guess);
    string CreateRandomNumber();
    void ExitGame();
    bool ToggleGameOn();
}
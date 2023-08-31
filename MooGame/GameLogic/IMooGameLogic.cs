namespace MooGame.GameLogic;

public interface IMooGameLogic
{
    bool TogglePracticeRun();
    string EvaluateGuessAndReturnNumberOfBullsAndCows(string goal, string guess);
    string CreateRandomNumber();
    void ExitGame();
    bool ToggleGameOn();
}
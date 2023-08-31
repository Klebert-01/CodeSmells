namespace MooGame.GameLogic;

public interface IMooGameLogic
{
    bool TogglePracticeRun();
    string EvaluateGuessAndGetNumberOfBullsAndCows(string goal, string guess);
    string CreateRandomNumber();
    bool ToggleGameOn();
}
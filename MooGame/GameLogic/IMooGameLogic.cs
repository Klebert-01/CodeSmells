namespace MooGame.GameLogic;

public interface IMooGameLogic
{
    bool TogglePracticeRun(string answer);
    string CheckPlayerGuess(string goal, string guess);
    string CreateRandomNumber();
}
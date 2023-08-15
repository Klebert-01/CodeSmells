namespace MooGame.GameLogic
{
    public interface IMooGameLogic
    {

        string CheckPlayerGuess(string goal, string guess);
        string CreateRandomNumber();
    }
}
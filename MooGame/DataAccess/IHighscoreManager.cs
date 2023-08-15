namespace MooGame.DataAccess
{
    public interface IHighscoreManager
    {
        void AddHighscore(string userName, int numberOfGuesses);
        void DisplayHighscore();
        List<PlayerData> GetHighscore();
    }
}
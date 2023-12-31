﻿namespace MooGame.Data;

public class HighscoreManager : IHighscoreManager
{
    private IUI _ui;
    public HighscoreManager(IUI ui)
    {
        _ui = ui;
    }
    public HighscoreManager()
    {

    }

    public List<PlayerData> GetHighscore()
    {
        var highScore = new List<PlayerData>();

        using (var reader = new StreamReader("result.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {

                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);

                var player = new PlayerData(name, guesses);

                int playerRank = highScore.IndexOf(player);

                if (playerRank < 0)
                {
                    highScore.Add(player);
                }
                else
                {
                    highScore[playerRank].Update(guesses);
                }
            }
            SortHighScoreTable(highScore);
        }
        return highScore;
    }
    public void DisplayHighscore()
    {
        using (var reader = new StreamReader("result.txt"))
        {
            string correctHighScoreFormatting = "{0,-9}{1,5:D}{2,9:F2}";

            var highScore = GetHighscore();

            _ui.Print("Player   Games  Average");

            foreach (var player in highScore)
            {
                _ui.Print(string.Format(correctHighScoreFormatting, player.Name, player.GamesPlayed, player.Average()));
            }
        }
    }
    public void AddHighscore(string userName, int numberOfGuesses)
    {
        using (var writer = new StreamWriter("result.txt", append: true))
        {
            writer.WriteLine($"{userName}#&#{numberOfGuesses}");
        }
    }

    private List<PlayerData> SortHighScoreTable(List<PlayerData> highScores)
    {
        highScores.Sort((playerData1, playerData2) => playerData1.Average().CompareTo(playerData2.Average()));
        return highScores;
    }
}



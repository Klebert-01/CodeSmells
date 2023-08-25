﻿namespace MooGame.Data;

public class HighscoreManager : IHighscoreManager
{

    private List<PlayerData> SortHighScoreTable(List<PlayerData> highScores)
    {
        highScores.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        return highScores;
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

                #region CheckPlayerRanking
                int playerRank = highScore.IndexOf(player);
                #endregion

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
    public void DisplayHighscore() // should return the string instead of cw
    {

        using (var reader = new StreamReader("result.txt"))
        {

            var highScore = GetHighscore();

            #region displayHighScores
            Console.WriteLine("Player   games average");

            foreach (var player in highScore)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.GamesPlayed, player.Average()));
            }
            #endregion
        }
    }
    public void AddHighscore(string userName, int numberOfGuesses)
    {

        using (var writer = new StreamWriter("result.txt", append: true))
        {
            writer.WriteLine($"{userName}#&#{numberOfGuesses}");
        }
    }

}


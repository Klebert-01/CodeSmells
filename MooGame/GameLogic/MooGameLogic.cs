namespace MooGame.GameLogic;


public static class MooGameLogic
{
    public static void StartNewGame()
    {
        CreateRandomNumber();
    }
    
    private static bool PlayerGuessIsInvalid(string guess)
    {
        if(guess.Length != 4)
        {
            return true;
        }
        return false;
    }



    public static string CreateRandomNumber() 
    {
        Random numberGenerator = new();
        int targetNumber = numberGenerator.Next(10000);

        return targetNumber.ToString();
    }

    public static string CheckPlayerGuess(string goal, string guess) //switch places goal and guess as params to guess, goal
    {
        int cows = 0, bulls = 0; //gör om till eget "bullsandcows" objekt och sätt dessa till default i konstruktorn



        if (PlayerGuessIsInvalid(guess))
        {
            return "guess must be exactly 4 digits long";
        }


        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }

    public static void DisplayHighscore() //method for getting and writing highscores SHOULD USE JSON INSTEAD
    {

        StreamReader input = new StreamReader("result.txt"); //store as json instead
        List<PlayerData> results = new List<PlayerData>();
        string line;
        while ((line = input.ReadLine()) != null)
        {

            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None); //weird to store name and score as array and not separate datatypes
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);

            PlayerData pd = new PlayerData(name, guesses);
            int pos = results.IndexOf(pd);
            if (pos < 0)
            {
                results.Add(pd);
            }
            else
            {
                results[pos].Update(guesses);
            }


        }


        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.GamesPlayed, p.Average()));
        }
        input.Close();
    }
}

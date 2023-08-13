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
        int targetNumber = numberGenerator.Next(999,10000);

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
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);    //TODO den här genererar nån bugg. Ibland BBBB,CC vid rätt svar ibland inte
    }
}

namespace MooGame.GameLogic;


public class MooGameLogic : IMooGameLogic
{

    private bool PlayerGuessIsInvalid(string guess)
    {
        if (guess.Length != 4)
        {
            return true;
        }
        return false;
    }



    public string CreateRandomNumber()
    {
        Random numberGenerator = new();
        int targetNumber = numberGenerator.Next(999, 10000);

        return targetNumber.ToString();
    }

    public string CheckPlayerGuess(string goal, string guess) // dela upp
    {
        int cows = 0, bulls = 0;

        guess += "    ";

        //if (PlayerGuessIsInvalid(guess))
        //{
        //    return "guess must be exactly 4 digits long";   //when this triggers 
        //}

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

        string numberOfBullsAndCows = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);

        return numberOfBullsAndCows;    //TODO den här genererar nån bugg. Ibland BBBB,CC vid rätt svar ibland inte
    }
}

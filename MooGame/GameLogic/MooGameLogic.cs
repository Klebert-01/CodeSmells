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
        //utkommenterat genererade BBBB,CC buggen vid rätt svar. kolla upp varför

        //Random numberGenerator = new();
        //int targetNumber = numberGenerator.Next(999, 10000);

        //return targetNumber.ToString();

        Random randomGenerator = new Random();
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }
            goal = goal + randomDigit;
        }
        return goal;
    }

    public string CheckPlayerGuess(string goal, string guess)
    {
        int cows = 0, bulls = 0;

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

        string numberOfBullsAndCows = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);

        return numberOfBullsAndCows;
    }
}

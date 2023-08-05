namespace GameResources.GameLogic;

public static class MooGameLogic
{
    public static string makeGoal()    //does a lot of things, extract to smaller methods 
    {
        Random randomGenerator = new Random(); //creates new random object
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
            goal = goal + randomDigit; // change to += operator
        }
        return goal;
    }

    /*
     * method does a few different things: keeps track of bulls and cows, error handling for wrong input, and more?
     */
    public static string checkBC(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    ";     // if player entered less than 4 chars
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
}

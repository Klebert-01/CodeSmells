using GameResources.Data;

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

    public static void showTopList() //method for getting and writing highscores
    {

        StreamReader input = new StreamReader("result.txt");
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
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
        }
        input.Close();
    }
}

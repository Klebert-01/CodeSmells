public static class MooGameLogic    //borde ligga i moogameprojektet och sen ärva av ett gamelogic interface? 


{
    public static string CreateTargetNumber()    //does a lot of things, extract to smaller methods 
    {

        Random numberGenerator = new();

        int targetNumber = numberGenerator.Next(10000);

        return targetNumber.ToString();

        //Random numberGenerator = new(); //creates new random object

        //string targetNumber = "";

        //for (int i = 0; i < 4; i++)
        //{
        //    int random = numberGenerator.Next(10);
        //    string randomDigit = "" + random;

        //    while (targetNumber.Contains(randomDigit))
        //    {
        //        random = numberGenerator.Next(10);
        //        randomDigit = "" + random;
        //    }
        //    targetNumber += randomDigit;
        //}
        //return targetNumber;
    }

    /*
     * method does a few different things: keeps track of bulls and cows, error handling for wrong input, and more?
     */
    public static string CheckPlayerGuess(string goal, string guess)
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

    public static void DisplayHighscore() //method for getting and writing highscores
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

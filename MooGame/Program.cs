namespace MooGame;

class MainClass
{

    public static void Main(string[] args)
    {

        bool playOn = true;

        #region TakeUserInput
        Console.WriteLine("Enter your user name:\n"); //extract to method returning string
        string name = Console.ReadLine();
        #endregion

        while (playOn)
        {

            string goal = MooGameLogic.makeGoal();


            Console.WriteLine("New game:\n");
            //comment out or remove next line to play real games!
            Console.WriteLine("For practice, number is: " + goal + "\n");
            string guess = Console.ReadLine();  // TODO parse to int directly

            int nGuess = 1;
            string bbcc = MooGameLogic.checkBC(goal, guess);
            Console.WriteLine(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                nGuess++;
                guess = Console.ReadLine();
                Console.WriteLine(guess + "\n");
                bbcc = MooGameLogic.checkBC(goal, guess);
                Console.WriteLine(bbcc + "\n");
            }
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + nGuess);
            output.Close();
            MooGameLogic.showTopList();
            Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = Console.ReadLine();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
        }
    }
}


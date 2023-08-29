namespace MooGame.GameLogic;


public class MooGameLogic : IMooGameLogic
{
    private IUI _ui;
    public MooGameLogic(IUI ui)
    {
        _ui = ui;
    }
    public MooGameLogic()
    {

    }

    private bool PlayerGuessIsValid(string guess)
    {
        if (guess.Length != 4)
        {
            return false;
        }

        foreach (char c in guess)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }

    public bool TogglePracticeRun()    //utveckla felhantering för felinput
    {
        _ui.Print("Practice run? Y/N");

        string answer = _ui.GetInput();

        if (answer.ToUpper() == "Y")
        {
            return true;
        }
        return false;
    }


    public string CreateRandomNumber()
    {
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
            goal += randomDigit;
        }
        return goal;
    }



    public string CheckPlayerGuess(string goal, string guess)
    {
        int numberOfCows = 0, numberOfBulls = 0;

        if (PlayerGuessIsValid(guess))
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            numberOfBulls++;
                        }
                        else
                        {
                            numberOfCows++;
                        }
                    }
                }
            }
            string numberOfBullsAndCows = "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);

            return numberOfBullsAndCows;
        }
        else
        {
            return "guess must be exactly 4 digits long, try again:";
        }
    }

    public void ExitGame()
    {
        Environment.Exit(0);
    }
}

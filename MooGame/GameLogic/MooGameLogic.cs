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

    public bool TogglePracticeRun()
    {
        string answer;

        do
        {
            _ui.Print("Practice run? Y/N");
            answer = _ui.GetInput().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            else if (answer == "N")
            {
                return false;
            }
            else
            {
                _ui.Print("Invalid input. Enter 'Y' or 'N'");
            }
        } while (true);
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
            string numberOfBullsAndCows = FormatBullsAndCows(numberOfCows, numberOfBulls);

            return numberOfBullsAndCows;
        }
        else
        {
            return "guess must be exactly 4 digits long, try again:";
        }
    }


    public bool ToggleGameOn()
    {
        string answer;

        do
        {
            _ui.Print("Continue? Y/N");
            answer = _ui.GetInput().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            else if (answer == "N")
            {
                return false;
            }
            else
            {
                _ui.Print("Invalid input. Enter 'Y' or 'N'");
            }
        } while (true);
    }

    public void ExitGame()
    {
        Environment.Exit(0);
    }
    private string FormatBullsAndCows(int numberOfCows, int numberOfBulls)
    {
        return "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);
    }
}

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

    public bool TogglePracticeRun()
    {
        _ui.Print("Practice run? Y/N");

        return GetYesOrNoResponse();
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
    public string EvaluateGuessAndGetNumberOfBullsAndCows(string goal, string guess) //split into methods for bulls and for cows?
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
        _ui.Print("Continue? Y/N");

        return GetYesOrNoResponse();
    }
    public void ExitGame()// unused remove if not to be implemented
    {
        Environment.Exit(0);
    }

    private string FormatBullsAndCows(int numberOfCows, int numberOfBulls)
    {
        return "BBBB".Substring(0, numberOfBulls) + "," + "CCCC".Substring(0, numberOfCows);
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

    private bool GetYesOrNoResponse() //refactor name to more proper one
    {
        string answer;
        do
        {
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
}

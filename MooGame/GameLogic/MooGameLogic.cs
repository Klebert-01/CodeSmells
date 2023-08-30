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
        bool validInput = false;
        string answer;

        do
        {
            _ui.Print("Practice run? Y/N");
            answer = _ui.GetInput();

            if (answer.ToUpper() == "Y")
            {
                return true;
            }
            else if (answer.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                _ui.Print("Invalid input. Enter 'Y' or 'N'");
            }
        } while (!validInput);

        return validInput;  //this should not be needed, the method can never reach this point but without it i get CS0161 not all code paths return value. 
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

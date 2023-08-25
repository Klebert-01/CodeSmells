using MooGame.GameLogic;

namespace MooGame.Controllers;

public class MooGameController
{
    private IHighscoreManager _highscoreManager;
    private IMooGameLogic _mooGameLogic;
    private IUI _ui;
    public MooGameController(IHighscoreManager highscoreManager, IMooGameLogic mooGameLogic, IUI ui)
    {
        _highscoreManager = highscoreManager;
        _mooGameLogic = mooGameLogic;
        _ui = ui;
    }

    public void StartGame()
    {
        bool playOn = true;


        _ui.Print("Enter your username: ");
        string userName = _ui.GetPlayerUsername();

        while (playOn)
        {
            string correctNumber = _mooGameLogic.CreateRandomNumber();

            _ui.Print("New game:\n");

            #region PracticeRunToggle
            //comment out or remove next line to play real games!
            _ui.Print($"For practice, correct number is: {correctNumber}\n");
            #endregion


            string guess = _ui.GetInput();

            int numberOfGuesses = 1;
            string bullsAndCowsResult = _mooGameLogic.CheckPlayerGuess(correctNumber, guess);

            #region DisplayBullsAndCows
            _ui.Print($"{bullsAndCowsResult} \n");
            #endregion

            while (bullsAndCowsResult != "BBBB,")
            {
                numberOfGuesses++;
                guess = _ui.GetInput();
                _ui.Print($"{guess} \n");
                bullsAndCowsResult = _mooGameLogic.CheckPlayerGuess(correctNumber, guess);
                _ui.Print($"{bullsAndCowsResult} \n");

            }

            _highscoreManager.AddHighscore(userName, numberOfGuesses);
            _highscoreManager.DisplayHighscore();

            #region DisplayNoOfGuessesAndAskPlayerAboutNewGame
            _ui.Print($"Correct, it took {numberOfGuesses} guesses\nContinue?");

            string answer = _ui.GetInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
            #endregion
        }
    }
}


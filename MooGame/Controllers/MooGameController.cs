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


        string userName = _ui.GetPlayerUsername();

       
        while (playOn)
        {
            string correctNumber = _mooGameLogic.CreateRandomNumber();

            _ui.Print("New game:");
            _ui.Print("Practice run? Y/N");
            string answer = _ui.GetInput();

            if (_mooGameLogic.TogglePracticeRun(answer))    //borde ändra och ta emot svaret ovan if statement, om answer = true => practicerunmetod inom ifblocket
            {
                _ui.Print($"Correct number is: {correctNumber}\n");
            }
            else
            {
                _ui.Print("Make your guess:");
            }



            string guess = _ui.GetInput();

            int numberOfGuesses = 1;
            string bullsAndCowsResult = _mooGameLogic.CheckPlayerGuess(correctNumber, guess);

            _ui.Print($"{bullsAndCowsResult} \n");

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

            //#region DisplayNoOfGuessesAndAskPlayerAboutNewGame
            _ui.Print($"Correct, it took {numberOfGuesses} guesses\nContinue?");

            answer = _ui.GetInput();

            if (answer.ToUpper() != "Y")    //this works but does not factor in wrong input, maybe need else if
            {
                playOn = false;
            }
        }
    }
}


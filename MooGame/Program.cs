var ui = new ConsoleUI();
var dataAccess = new HighscoreManager();
var gameLogic = new MooGameLogic();


bool playOn = true;


ui.Print("Enter your username: ");
string userName = ui.GetPlayerUsername();

while (playOn)
{
    string correctNumber = gameLogic.CreateRandomNumber();

    ui.Print("New game:\n");

    #region PracticeRunToggle
    //comment out or remove next line to play real games!
    ui.Print($"For practice, correct number is: {correctNumber}\n");
    #endregion


    string guess = ui.GetInput();

    int numberOfGuesses = 1;
    string bullsAndCowsResult = gameLogic.CheckPlayerGuess(correctNumber, guess);

    #region DisplayBullsAndCows
    ui.Print($"{bullsAndCowsResult} \n");
    #endregion

    while (bullsAndCowsResult != "BBBB,")
    {
        numberOfGuesses++;
        guess = ui.GetInput();
        ui.Print($"{guess} \n");
        bullsAndCowsResult = gameLogic.CheckPlayerGuess(correctNumber, guess);
        ui.Print($"{bullsAndCowsResult} \n");

    }

    dataAccess.AddHighscore(userName, numberOfGuesses);
    dataAccess.DisplayHighscore();

    #region DisplayNoOfGuessesAndAskPlayerAboutNewGame
    ui.Print($"Correct, it took {numberOfGuesses} guesses\nContinue?");

    string answer = ui.GetInput();
    if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
    {
        playOn = false;
    }
    #endregion
}


var io = new ConsoleIO();
var dataAccess = new HighscoreManager();

bool playOn = true;


io.Print("Enter your username: ");
string userName = io.GetPlayerUsername();

while (playOn)
{
    string correctNumber = MooGameLogic.CreateRandomNumber();

    io.Print("New game:\n");

    #region PracticeRunToggle
    //comment out or remove next line to play real games!
    io.Print($"For practice, correct number is: {correctNumber}\n");
    #endregion


    string guess = io.GetInput();  // TODO parse to int directly

    int nGuess = 1;
    string bbcc = MooGameLogic.CheckPlayerGuess(correctNumber, guess);

    #region DisplayGuess?
    io.Print($"{bbcc} \n");
    #endregion

    while (bbcc != "BBBB,")
    {
        nGuess++;
        guess = io.GetInput();
        io.Print($"{guess} \n");
        bbcc = MooGameLogic.CheckPlayerGuess(correctNumber, guess);
        io.Print($"{bbcc} \n");

    }

    dataAccess.AddHighscore(userName, nGuess);

    MooGameLogic.DisplayHighscore();

    #region DisplayNoOfGuessesAndAskPlayerAboutNewGame
    io.Print($"Correct, it took {nGuess} guesses\nContinue?");
    string answer = io.GetInput();
    if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
    {
        playOn = false;
    }
    #endregion
}

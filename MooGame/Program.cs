var ui = new ConsoleUI();
var highscoreManager = new HighscoreManager();
var gameLogic = new MooGameLogic();

MooGameController gameController = new(highscoreManager, gameLogic, ui);
gameController.StartGame();


var ui = new ConsoleUI();
var highscoreManager = new HighscoreManager();
var gameLogic = new MooGameLogic();

var gameController = new MooGameController(highscoreManager, gameLogic, ui);
gameController.StartGame();

var ui = new ConsoleUI();
var highscoreManager = new HighscoreManager();
var gameLogic = new MooGameLogic(ui);

var gameController = new MooGameController(highscoreManager, gameLogic, ui);
gameController.StartGame();

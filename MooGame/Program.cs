var ui = new ConsoleUI();
var highscoreManager = new HighscoreManager(ui);
var gameLogic = new MooGameLogic(ui);

var gameController = new MooGameController(highscoreManager, gameLogic, ui);

gameController.StartGame();

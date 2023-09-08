using MooGame.Data;

namespace MooGameTest;

[TestClass]
public class HighscoreManagerTest
{
    private HighscoreManager _highscoreManager;

    [TestInitialize]
    public void Initialize()
    {
        _highscoreManager = new HighscoreManager();
    }

    [TestMethod]
    public void AddHighscore_SuccessfullyWritesToFile()
    {
        string userName = "TestUser";
        int numberOfGuesses = 5;
        string expectedResult = $"{userName}#&#{numberOfGuesses}";

        _highscoreManager.AddHighscore(userName, numberOfGuesses);

        using (var reader = new StreamReader("result.txt"))
        {
            string actualResult = reader.ReadLine();
            Assert.AreEqual(expectedResult, actualResult);
        }

        File.Delete("result.txt");
    }
}

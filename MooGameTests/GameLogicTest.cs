
namespace MooGameTest;

[TestClass]
public class GameLogicTest
{
    private MooGameLogic _gameLogic;

    [TestInitialize]
    public void Initialize()
    {
        _gameLogic = new MooGameLogic();
    }

    [TestMethod]
    public void CreateRandomNumber_CorrectLength()
    {
        string randomNumber = _gameLogic.CreateRandomNumber();

        Assert.AreEqual(4, randomNumber.Length);
    }
    [TestMethod]
    public void CreateRandomNumber_OnlyNumericValues()
    {
        string randomNumber = _gameLogic.CreateRandomNumber();

        foreach (char c in randomNumber)
        {
            Assert.IsTrue(char.IsDigit(c));
        }
    }

}

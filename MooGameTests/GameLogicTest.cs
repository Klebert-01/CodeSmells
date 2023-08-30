using MooGame.GameLogic;

namespace MooGameTest;

[TestClass]
public class GameLogicTest
{
    private MooGameLogic gameLogic;

    [TestInitialize]
    public void Initialize()
    {
        gameLogic = new MooGameLogic();
    }

    [TestMethod]
    public void CreateRandomNumber_CorrectLenght()
    {
        string randomNumber = gameLogic.CreateRandomNumber();

        Assert.AreEqual(4, randomNumber.Length);
    }
    [TestMethod]
    public void CreateRandomNumber_OnlyNumericValues()
    {
        string randomNumber = gameLogic.CreateRandomNumber();

        foreach (char c in randomNumber)
        {
            Assert.IsTrue(char.IsDigit(c));
        }
    }

}

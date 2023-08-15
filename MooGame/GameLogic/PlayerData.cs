namespace MooGame.GameLogic;


public class PlayerData
{

    public string Name { get; private set; }
    public int GamesPlayed { get; private set; }    //only games played for active session? called Nguesses before
    public int TotalGuesses { get; private set; }   //total guesses per game?


    public PlayerData(string name, int totalGuesses)
    {
        Name = name;
        GamesPlayed = 1;
        TotalGuesses = totalGuesses;
    }

    public void Update(int guesses)
    {
        TotalGuesses += guesses;
        GamesPlayed++;
    }

    public double Average()
    {
        return (double)TotalGuesses / GamesPlayed;
    }

    // no references to this in proj what is the purpose
    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }

    // no references to this in proj
    public override int GetHashCode()   //why have our own method that returns GetHashCode from the string class?
    {
        return Name.GetHashCode();
    }
}

public class PlayerData
{

    public string Name { get; private set; }
    public int NGames { get; private set; }
    int totalGuess;


    public PlayerData(string name, int guesses)
    {
        this.Name = name;
        NGames = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)totalGuess / NGames;
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

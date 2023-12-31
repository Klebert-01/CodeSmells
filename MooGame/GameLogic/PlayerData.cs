﻿namespace MooGame.GameLogic;


public class PlayerData
{
    public string Name { get; private set; }
    public int GamesPlayed { get; private set; }
    public int TotalGuesses { get; private set; }

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
    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

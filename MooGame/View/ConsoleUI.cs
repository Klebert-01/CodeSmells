﻿namespace MooGame.View;


public class ConsoleUI : IUI
{
    public string GetPlayerUsername()
    {
        string? userName = string.Empty;

        Console.WriteLine("Enter your username: ");

        userName = Console.ReadLine();

        if (userName == "" || userName == null)
        {
            userName = "Unknown";
        }

        return userName;
    }
    public string GetInput()
    {
        return Console.ReadLine();
    }
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}

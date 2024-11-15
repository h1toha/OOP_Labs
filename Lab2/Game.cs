namespace lab2;
using System;
using System.Collections.Generic;
using NanoidDotNet;

public abstract class Game
{
    public string Player1 { get; }
    public string Player2 { get; }
    public int Rating { get; protected set; }
    public string GameId { get; }
    public string Winner { get; }
    public virtual bool IsRated { get { return true; } }
    public GameType GameType { get; }
    public static readonly Dictionary<string, Game> Games = new();

    public Game(string player1, string player2, string winner, int rating, GameType type)
    {
        if (rating < 0)
            throw new ArgumentException("Rating cannot be negative.");
        if (player1 == player2)
            throw new ArgumentException("Players cannot be the same.");
        if (player1 == null || player2 == null || winner == null)
            throw new ArgumentException("Player names cannot be null.");
        if (player1 == "" || player2 == "" || winner == "")
            throw new ArgumentException("Player names cannot be empty.");

        Player1 = player1;
        Player2 = player2;
        Rating = rating;
        GameId = Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 10);
        Winner = winner;
        GameType = type;
        Games.Add(GameId, this);
    }

    public void ProcessGame()
    {
        var player1 = GameAccount.GetAccountByName(Player1);
        var player2 = GameAccount.GetAccountByName(Player2);

        if (Winner == player1.UserName)
        {
            player1.WinGame(this);
            player2.LoseGame(this);
        }
        else
        {
            player1.LoseGame(this);
            player2.WinGame(this);
        }
    }

    public bool IsWin(string playerName)
    {
        return Winner == playerName;
    }
    public string GetOpponent(string playerName)
    {
        return playerName == Player1 ? Player2 : Player1;
    }
}

public class StandartGame(string player1, string player2, string winner, int rating) : Game(player1, player2, winner, rating, GameType.Standart);
public class TrainingGame(string player1, string player2, string winner) : Game(player1, player2, winner, 0, GameType.Training);
public class WinnerTakesAllGame(string player1, string player2, string winner, int rating) : Game(player1, player2, winner, rating, GameType.WinnerTakesAll)
{
    public override bool IsRated { get { return false; } }

}
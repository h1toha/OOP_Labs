namespace lab2;
using System;
using System.Collections.Generic;
using static GameType;

public abstract class GameAccount
{
    public string UserName { get; protected set; }
    public int CurrentRating { get; protected set; }
    public int GamesCount { get { return gamesHistory.Count; } }
    protected List<Game> gamesHistory;
    private static readonly Dictionary<string, GameAccount> Accounts = new();

    public GameAccount(string userName, int currentRating)
    {
        if (currentRating < 0)
            throw new ArgumentException("Rating cannot be negative.");
        if (userName == null)
            throw new ArgumentException("User name cannot be null.");
        if (userName == "")
            throw new ArgumentException("User name cannot be empty.");

        UserName = userName;
        CurrentRating = currentRating;
        gamesHistory = new List<Game>();
        Accounts.Add(UserName, this);
    }

    public virtual void WinGame(Game game)
    {
        CurrentRating += game.Rating;
        gamesHistory.Add(game);
    }

    public virtual void LoseGame(Game game)
    {
        if (game.Winner == UserName)
            throw new ArgumentException("You cannot lose a game you won.");

        if (game.IsRated)
        {
            CurrentRating = Math.Max(1, CurrentRating - game.Rating);
        }
        gamesHistory.Add(game);
    }

    public virtual void GetStats()
    {

        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("Opponent:\t Result:\t Rating:\t Game Type:\t\t\t Game ID:");

        foreach (var game in gamesHistory)
        {

            string result = game.IsWin(UserName) ? "Win" : "Loss";
            Console.Write($"{game.GetOpponent(UserName)}\t ");
            if (result == "Win")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{result}");
            Console.ResetColor();
            if (game.IsWin(UserName))
            {
                if (game.Rating == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {game.Rating}");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\t\t +{game.Rating}");
                }

            }
            else
            {
                if (game.IsRated == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {0}");

                }
                else
                if (game.Rating == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {game.Rating}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\t\t -{game.Rating}");
                }
            }
            switch (game.GameType)
            {
                case Standart:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                case Training:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                case WinnerTakesAll:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.ResetColor();
            Console.WriteLine($"\t\t\t {game.GameId}\t");
        }

        Console.WriteLine($"\nCurrent Rating: {CurrentRating}");
        Console.WriteLine($"Total Games Played: {GamesCount}");
        Console.WriteLine("--------------------------------------------------------------------------------------------\n");
    }
    public static GameAccount GetAccountByName(string user)
    {
        if (Accounts.TryGetValue(user, out var account))
        {
            return account;
        }

        throw new ArgumentException("Invalid user ID.");
    }
}

public class StandartAccount(string userName, int currentRating) : GameAccount(userName, currentRating);

public class PremiumAccount(string userName, int currentRating) : GameAccount(userName, currentRating)
{
    public override void LoseGame(Game game)
    {
        if (game.Winner == UserName)
            throw new ArgumentException("You cannot lose a game you won.");

        if (game.IsRated)
        {
            CurrentRating = Math.Max(1, CurrentRating - game.Rating / 2);
        }
        gamesHistory.Add(game);
    }
}

public class StreakAccount(string userName, int currentRating) : GameAccount(userName, currentRating)
{
    private int WinStreak { get; set; }
    private Dictionary<string, int> WinStreakHistory { get; } = new();

    private void UpdateWinStreak(Game game)
    {
        if (game.GameType is GameType.Standart or GameType.WinnerTakesAll && game.Winner == UserName)
        {
            WinStreak++;
        }
        else if (game.GameType != GameType.Training)
        {
            WinStreak = 0;
        }

        WinStreakHistory.Add(game.GameId, WinStreak);
    }
    public override void WinGame(Game game)
    {
        CurrentRating += game.Rating + WinStreak;

        gamesHistory.Add(game);
        UpdateWinStreak(game);
    }

    public override void LoseGame(Game game)
    {
        base.LoseGame(game);
        UpdateWinStreak(game);
    }

    public override void GetStats()
    {
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine($"Game history for {UserName}:\n");
        Console.WriteLine("Opponent:\t Result:\t Rating:\t Game Type: \t  Win Streak:\t Game ID:");

        foreach (var game in gamesHistory)
        {

            string result = game.IsWin(UserName) ? "Win" : "Loss";
            Console.Write($"{game.GetOpponent(UserName)}\t ");
            if (result == "Win")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{result}");
            Console.ResetColor();
            if (game.IsWin(UserName))
            {
                if (game.Rating == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {game.Rating}");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\t\t +{game.Rating}");
                }

            }
            else
            {
                if (game.IsRated == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {0}");
                }
                else
                if (game.Rating == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\t\t {game.Rating}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\t\t -{game.Rating}");
                }
            }
            switch (game.GameType)
            {
                case Standart:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                case Training:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                case WinnerTakesAll:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"\t\t {game.GameType}");
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.ResetColor();
            Console.WriteLine($"\t  {WinStreakHistory[game.GameId]}\t\t {game.GameId}\t");
        }

        Console.WriteLine($"\nCurrent Rating: {CurrentRating}");
        Console.WriteLine($"Total Games Played: {GamesCount}");
        Console.WriteLine("--------------------------------------------------------------------------------------------\n");
    }
}


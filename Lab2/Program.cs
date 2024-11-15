namespace lab2;
using System;
using Lab2;

public class Program
{
    public static void Main()
    {
        var player1 = new StandartAccount("CoolGamer228", 100);
        var player2 = new PremiumAccount("KillerPro_", 100);
        var player3 = new StreakAccount("GameMaster69", 100);

        Console.WriteLine($"\nSimulating games for {player1.UserName}, {player2.UserName}, and {player3.UserName}...\n");

        Console.WriteLine($"Current rating of {player1.UserName}: {player1.CurrentRating}");
        Console.WriteLine($"Current rating of {player2.UserName}: {player2.CurrentRating}");
        Console.WriteLine($"Current rating of {player3.UserName}: {player3.CurrentRating}\n");

        var game1 = GameFactory.CreateGame(GameType.Standart, player1.UserName, player2.UserName, player1.UserName, 10);
        var game2 = GameFactory.CreateGame(GameType.Standart, player2.UserName, player3.UserName, player3.UserName, 20);
        var game3 = GameFactory.CreateGame(GameType.Standart, player3.UserName, player1.UserName, player3.UserName, 30);
        var game4 = GameFactory.CreateGame(GameType.Training, player1.UserName, player2.UserName, player1.UserName);
        var game6 = GameFactory.CreateGame(GameType.Training, player3.UserName, player1.UserName, player3.UserName);
        var game7 = GameFactory.CreateGame(GameType.WinnerTakesAll, player1.UserName, player2.UserName, player1.UserName, 70);
        var game8 = GameFactory.CreateGame(GameType.WinnerTakesAll, player2.UserName, player3.UserName, player2.UserName, 80);
        var game9 = GameFactory.CreateGame(GameType.WinnerTakesAll, player3.UserName, player1.UserName, player3.UserName, 90);

        GameProcesing.ProcessAllGames();
        Console.WriteLine($"{player1.UserName} ({player1.GetType().Name}) Stats");
        player1.GetStats();

        Console.WriteLine($"\n{player2.UserName} ({player2.GetType().Name}) Stats");
        player2.GetStats();

        Console.WriteLine($"\n{player3.UserName} ({player3.GetType().Name}) Stats");
        player3.GetStats();
    }
}


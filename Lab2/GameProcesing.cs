namespace Lab2;
using lab2;
public static class GameProcesing
{
    public static void ProcessAllGames()
    {
        foreach (var game in Game.Games.Values) game.ProcessGame();
    }
}
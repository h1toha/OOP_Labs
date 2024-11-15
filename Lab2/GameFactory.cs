namespace lab2;

public static class GameFactory
{
    public static Game CreateGame(GameType gameType, string player1, string player2, string winner, int rating = 0)
    {
        if (gameType == GameType.Standart)
            return new StandartGame(player1, player2, winner, rating);
        if (gameType == GameType.Training)
            return new TrainingGame(player1, player2, winner);
        if (gameType == GameType.WinnerTakesAll)
            return new WinnerTakesAllGame(player1, player2, winner, rating);
        throw new ArgumentException("Invalid game.");
    }
}

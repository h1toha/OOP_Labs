using Lab3.GameAccounts;
using Lab3.Games;

namespace Lab3
{
    public static class Factory
    {
        public static Game CreateGame(GameType gameType, GameAccount player1, GameAccount player2, int rating, bool isWin)
        {
            if (gameType == GameType.StandardGame)
            {
                return new StandardGame(player1, player2, gameType, rating, isWin);
            }
            else if (gameType == GameType.TrainingGame)
            {
                return new TrainingGame(player1, player2, gameType, isWin);
            }
            else if (gameType == GameType.OnePlayerGame)
            {
                return new OnePlayerGame(player1, gameType, rating, isWin);
            }
            else
            {
                throw new System.ArgumentException("Invalid game type.");
            }
        }
        public static GameAccount CreateGameAccount(AccountType accountType, string username, int startingRating = 1)
        {
            if (accountType == AccountType.Standard)
            {
                return new StandardAccount(username, accountType, startingRating);
            }
            else if (accountType == AccountType.Streak)
            {
                return new BonusStreakAccount(username, accountType, startingRating);
            }
            else if (accountType == AccountType.HalfLoss)
            {
                return new HalfLossAccount(username, accountType, startingRating);
            }
            else
            {
                throw new System.ArgumentException("Invalid account type.");
            }

        }
    }
}

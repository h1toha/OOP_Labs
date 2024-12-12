using Lab3.Games;
using Lab3.GameAccounts;


namespace Lab3.GameAccounts
{
    public class BonusStreakAccount : GameAccount
    {
        private int _countGames = 0;
        public BonusStreakAccount(string userName, AccountType accountType, int startingRating = 1) : base(userName, accountType, startingRating)
        {
            accountType = AccountType.Streak;
        }
        private int CountWins()
        {
            if (_countGames == 3)
            {
                _countGames = 0;
                return 2;
            }
            else
            {
                _countGames++;
                return 0;
            }
        }
        public override void WinGame(Game game)
        {
            CurrentRating += game.CalculateRating() + CountWins();
        }
    }
}

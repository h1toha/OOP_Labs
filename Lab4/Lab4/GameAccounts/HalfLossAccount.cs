using Lab3.Games;


namespace Lab3.GameAccounts
{
    public class HalfLossAccount : GameAccount
    {
        public HalfLossAccount(string userName, AccountType accountType, int startingRating = 1) : base(userName, accountType, startingRating)
        {
            accountType = AccountType.HalfLoss;
        }

        public override void LoseGame(Game game)
        {
            CurrentRating -= game.CalculateRating() / 2;
        }
    }
}

using Lab3.Games;


namespace Lab3.GameAccounts
{
    public class StandardAccount : GameAccount
    {
        public StandardAccount(string userName, AccountType accountType, int startingRating = 1) : base(userName, accountType, startingRating)
        {
            accountType = AccountType.Standard;
        }

        public override void LoseGame(Game game)
        {
            CurrentRating -= game.CalculateRating();
        }
    }
}

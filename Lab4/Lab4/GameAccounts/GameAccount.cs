using Lab3.Games;


namespace Lab3.GameAccounts
{
    public enum AccountType
    {
        Standard,
        HalfLoss,
        Streak
    }
    public abstract class GameAccount
    {
        private static int _id = 0;
        public int Id { get; }
        public string Username { get; set; }
        public AccountType AccountType { get; set; }
        private int _rating;
        public int CurrentRating
        {
            get { return _rating; }
            set
            {
                if (value > 1) { _rating = value; }
                else { _rating = 1; }
            }
        }

        public GameAccount(string username, AccountType accountType, int startingRating = 1)
        {
            Id = ++_id;
            Username = username;
            AccountType = accountType;
        }

        public virtual void WinGame(Game game)
        {
            CurrentRating = CurrentRating + game.CalculateRating();
        }
        public virtual void LoseGame(Game game)
        {
            CurrentRating = CurrentRating - game.CalculateRating();
        }
    }
}

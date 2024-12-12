using Lab3.GameAccounts;
using Lab3.Games;

namespace Lab3
{
    public class DbContext
    {
        public List<Game> Games { get; set; }
        public List<GameAccount> Accounts { get; set; }

        public DbContext()
        {
            Accounts = new List<GameAccount>();
            Games = new List<Game>();
        }
    }
}

using Lab3.GameAccounts;
using Lab3.Games;
using Lab3.Service;
using System.Security.Principal;

namespace Lab3.Repository
{
    public class GameAccountRepo : IGameAccountRepository
    {
        private readonly DbContext _dbContext;

        public GameAccountRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateGameAccount(GameAccount account)
        {
           _dbContext.Accounts.Add(account);
        }

        public GameAccount ReadGameAccount(int id)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public List<GameAccount> ReadAllGameAccounts()
        {
            return _dbContext.Accounts;
        }


        public void UpdateGameAccount(GameAccount account)
        {
            var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existingAccount != null)
            {
                existingAccount.Username = account.Username;
            }
        }

        public void DeleteGameAccount(GameAccount account)
        {
                _dbContext.Accounts.Remove(account);
        }

        public void PrintStats(GameAccount user)
        {
            var context = _dbContext.Games;
            var t = context.FindAll(g => g.Player1 == user || g.Player2 == user);
            if (t == null)
            {
                return;
            }
            Console.WriteLine($"\n{user.Username}:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Game Id|Opponent    |Result  |Rating  |Game type      ");
            for (int i = 0; i < t.Count(); i++)
            {
                var opponent = t[i].Player1 == user ? t[i].Player2 : t[i].Player1;
                var result = t[i].Player1 == user ? (t[i].IsPlayer1Win ? "Win" : "Lose") : (t[i].IsPlayer1Win ? "Lose" : "Win");

                if (opponent == null)
                {
                    Console.WriteLine($"{t[i].Id,-7}|{"N/A",-12}|{result,-8}|{t[i].Rating,-8}|{t[i].GetType().Name,-14}");
                }
                else
                {
                    Console.WriteLine($"{t[i].Id,-7}|{opponent.Username,-12}|{result,-8}|{t[i].Rating,-8}|{t[i].GetType().Name,-14}");
                }
            }
            Console.WriteLine($"\nGames count: {t.Count()}, Rating: {user.CurrentRating}");
            Console.WriteLine("----------------------------------------------------");
        }

    }
}
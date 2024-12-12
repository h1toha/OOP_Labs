using Lab3.GameAccounts;
using Lab3.Games;
using Lab3.Repository;
using Lab3.Service.Interface;

namespace Lab3.Service
{
    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository _accountRepository;

        public GameAccountService(IGameAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public GameAccount CreateGameAccount(AccountType accountType, string username, int startingRating = 1)
        {
            var account = Factory.CreateGameAccount(accountType, username, startingRating);
            _accountRepository.CreateGameAccount(account); 
            return account;
        }

        public List<GameAccount> ReadAllGameAccounts()
        {
            return _accountRepository.ReadAllGameAccounts();
        }

        public GameAccount ReadGameAccount(int id)
        {
            return _accountRepository.ReadGameAccount(id);
        }

        public void UpdateGameAccount(int id, string newUsername)
        {
            var account = _accountRepository.ReadGameAccount(id);

            if (account != null)
            {
                account.Username = newUsername;
                _accountRepository.UpdateGameAccount(account);  
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        

        public void DeleteGameAccount(int id)
        {
            var account = _accountRepository.ReadGameAccount(id);

            if (account != null)
            {
                _accountRepository.DeleteGameAccount(account); 
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void PrintStats(GameAccount user)
        {
            _accountRepository.PrintStats(user);
        }
    }
}

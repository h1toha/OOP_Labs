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

        public GameAccount GetGameAccountByID(int id)
        {
            return _accountRepository.GetGameAccountByID(id);
        }
        public GameAccount GetGameAccountByUsername(string username)
        {
            return _accountRepository.GetGameAccountByUsername(username);
        }

        public void UpdateGameAccount(int id, string newUsername)
        {
            var account = _accountRepository.GetGameAccountByID(id);

            if (account != null)
            {
                account.Username = newUsername; // Оновлюємо ім'я
                _accountRepository.UpdateGameAccount(account);    // Зберігаємо зміни
            }
            else
            {
                Console.WriteLine("Обліковий запис не знайдено.");
            }
        }
        

        public void DeleteGameAccount(int id)
        {
            var account = _accountRepository.GetGameAccountByID(id);

            if (account != null)
            {
                _accountRepository.DeleteGameAccount(account); // Викликаємо метод видалення
            }
            else
            {
                Console.WriteLine("Обліковий запис не знайдено.");
            }
        }

        public void PrintStats(GameAccount user)
        {
            _accountRepository.PrintStats(user);
        }
    }
}

using Lab3.GameAccounts;

namespace Lab3.Service.Interface
{
    public interface IGameAccountService
    {
        GameAccount CreateGameAccount(AccountType accountType, string username, int startingRating = 1);
        List<GameAccount> ReadAllGameAccounts();
        GameAccount GetGameAccountByID(int id);
        GameAccount GetGameAccountByUsername(string username);
        void UpdateGameAccount(int id, string newUsername);
        void DeleteGameAccount(int id);
        void PrintStats(GameAccount user);
    }
}

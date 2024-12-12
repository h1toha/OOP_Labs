using Lab3.GameAccounts;
using Lab3.Service;

namespace Lab3.Repository
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(GameAccount account); // метод для створення аккаунту
        GameAccount ReadGameAccount(int id); //метод для отримання інформації про аккаунт
        List<GameAccount> ReadAllGameAccounts(); // метод для отримання списку всіх гравців
        void UpdateGameAccount(GameAccount account); //метод для змінення інформації в аккаунті
        void DeleteGameAccount(GameAccount account); // метод для видалення аккаунту
        void PrintStats(GameAccount user); // метод для виведення статистики ігрока
    }
}

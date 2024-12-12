using Lab3.GameAccounts;
using Lab3.Games;

namespace Lab3.Repository
{
    public interface IGameRepository
    {
        void CreateGame(Game game); // метод для створення гри
        Game ReadGame(int id); // метод для отримання інформації про гру
        List<Game> ReadAllGames(); //метод для отримання списку всіх ігор
        void DeleteGame(Game game); // метод для видалення гри

    }
}
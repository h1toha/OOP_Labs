using Lab3.GameAccounts;
using Lab3.Games;

namespace Lab3.Service
{
    public interface IGameService
    {
        void PlayGame(GameType gameType, GameAccount player1, GameAccount player2);
        void DeleteGame(int id);
        Game ReadGame(int id);
        List<Game> ReadAllGames();
    }
}

using Lab3.GameAccounts;
using Lab3.Games;
using Lab3.Repository;


namespace Lab3.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void PlayGame(GameType gameType, GameAccount player1, GameAccount player2)
        {
            var game = Factory.CreateGame(gameType, player1, player2, new Random().Next(1, 51), new Random().Next(0, 2) == 1);
            game.ProcessGame();
            _gameRepository.CreateGame(game);
        }

        public Game ReadGame(int id)
        {
            return _gameRepository.ReadGame(id);
        }

        public List<Game> ReadAllGames()
        {
            return _gameRepository.ReadAllGames();
        }

        public void DeleteGame(int id)
        {
            var game = _gameRepository.ReadGame(id);

            if (game != null)
            {
                _gameRepository.DeleteGame(game);
            }
            else
            {
                Console.WriteLine("Game not found.");
            }
        }
    }
}

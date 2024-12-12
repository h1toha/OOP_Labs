using Lab3.GameAccounts;
using Lab3.Games;

namespace Lab3.Repository
{
    public class GameRepository : IGameRepository
    {

        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateGame(Game game)
        {
            _dbContext.Games.Add(game);
        }

        public Game ReadGame(int id)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public List<Game> ReadAllGames()
        {
            return _dbContext.Games;
        }

        public void DeleteGame(Game game)
        {
            _dbContext.Games.Remove(game);
        }
    }
}
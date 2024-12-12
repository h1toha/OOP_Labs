using Lab3.GameAccounts;
using Lab3.Games;
using Lab3.Repository;
using Lab3.Service;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DbContext(); 
            var gameAccountRepo = new GameAccountRepo(dbContext);
            var gameRepo = new GameRepository(dbContext);

            var gameAccountService = new GameAccountService(gameAccountRepo);
            var gameService = new GameService(gameRepo);

            gameAccountService.CreateGameAccount(AccountType.Standard, "CoolGamer228");
            gameAccountService.CreateGameAccount(AccountType.Streak, "KillerPro_");
            gameAccountService.CreateGameAccount(AccountType.HalfLoss, "Destroyer69");

            Console.WriteLine("List of all created players:");
            gameAccountService.ReadAllGameAccounts().ForEach(a => Console.WriteLine($"{a.Username}: Account type: {a.AccountType}"));

            Console.WriteLine();
            Console.WriteLine();

            gameService.PlayGame(GameType.StandardGame, gameAccountService.ReadGameAccount(1) , gameAccountService.ReadGameAccount(2));
            gameService.PlayGame(GameType.StandardGame, gameAccountService.ReadGameAccount(1), gameAccountService.ReadGameAccount(3));
            gameService.PlayGame(GameType.TrainingGame, gameAccountService.ReadGameAccount(2), gameAccountService.ReadGameAccount(3));
            gameService.PlayGame(GameType.StandardGame, gameAccountService.ReadGameAccount(2), gameAccountService.ReadGameAccount(3));
            gameService.PlayGame(GameType.TrainingGame, gameAccountService.ReadGameAccount(2), gameAccountService.ReadGameAccount(3));
            gameService.PlayGame(GameType.OnePlayerGame, gameAccountService.ReadGameAccount(1), null);
            gameService.PlayGame(GameType.OnePlayerGame, gameAccountService.ReadGameAccount(2), null);


            Console.WriteLine("List of games for a player:");
            gameAccountService.ReadAllGameAccounts().ForEach(a => gameAccountService.PrintStats(a));
            Console.WriteLine();

            Console.WriteLine("List of all games:");
            gameService.ReadAllGames().ForEach(g =>
            {
                var opponent = g.Player2 != null ? g.Player2.Username : "N/A";
                Console.WriteLine($"ID: {g.Id} Player: {g.Player1.Username}, Opponent: {opponent}, Rating: {g.Rating}, {(g.IsPlayer1Win ? "Win" : "Lose")}, Game type: {g.Type}");
            });
            Console.WriteLine();
            
        }
    }
}
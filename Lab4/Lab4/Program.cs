using Lab3.Repository;
using Lab3.Service;
using Lab3.UI;

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

            List<ICommand> users = new List<ICommand>()
            {
                new ReadAllAccoutsCommand(gameAccountService),
                new CreateGameAccountCommand(gameAccountService),
                new CreateGameCommand(gameAccountService, gameService),
                new PrintStatsCommand(gameAccountService)
            };

            while (true)
            {
                Console.WriteLine("\nChoose a command:");
                for (int i = 0; i < users.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    users[i].ShowInfo();
                    if (i == users.Count - 1)
                    {
                        Console.WriteLine($"{i + 2}. Exit");
                    }
                }
                if (int.TryParse(Console.ReadLine(), out int response))
                {
                    if (response > 0 && response <= users.Count)
                    {
                        users[response - 1].Action();
                    }
                    else if (response == users.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }
        }
    }
}
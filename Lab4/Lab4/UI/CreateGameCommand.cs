using Lab3.Games;
using Lab3.Repository;
using Lab3.Service;
using Lab3.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI
{
    public class CreateGameCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        private readonly IGameService _gameService;
        public CreateGameCommand(IGameAccountService accountService, IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Action()
        {
            string response1;
            string response2;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter first player (Type - 'exit' to cancel): ");
                response1 = Console.ReadLine();
                if (response1 == "exit")
                {
                    return;
                }
                if (_accountService.GetGameAccountByUsername(response1) == null)
                {
                    Console.WriteLine("Player not found.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Enter second player (Type - 'exit' to cancel): ");
                response2 = Console.ReadLine();
                if (response2 == "exit")
                {
                    return;
                }
                if (_accountService.GetGameAccountByUsername(response2) == null)
                {
                    Console.WriteLine("Player not found.");
                    continue;
                }
                break;
            }
            while (true)
            {
                if (response1 == response2)
                {
                    Console.WriteLine("Choose game type (Type - 'exit' to cancel): \n1. Single player game");
                    var response3 = Console.ReadLine();
                    if (response3 == "exit")
                    {
                        return;
                    }
                    switch (response3)
                    {
                        case "1":
                            _gameService.PlayGame(GameType.OnePlayerGame, _accountService.GetGameAccountByUsername(response1), _accountService.GetGameAccountByUsername(response2));
                            break;
                        default:
                            Console.WriteLine("Invslid choice.");
                            continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Choose game type (Type - 'exit' to cancel): \n1. Standart game\n2. Training game\n3. Single player game");
                    var response3 = Console.ReadLine();
                    if (response3 == "exit")
                    {
                        return;
                    }
                    switch (response3)
                    {
                        case "1":
                            _gameService.PlayGame(GameType.StandardGame, _accountService.GetGameAccountByUsername(response1), _accountService.GetGameAccountByUsername(response2));
                            break;
                        case "2":
                            _gameService.PlayGame(GameType.TrainingGame, _accountService.GetGameAccountByUsername(response1), _accountService.GetGameAccountByUsername(response2));
                            break;
                        case "3":
                            _gameService.PlayGame(GameType.OnePlayerGame, _accountService.GetGameAccountByUsername(response1), _accountService.GetGameAccountByUsername(response2));
                            break;
                        default:
                            Console.WriteLine("Invslid choice.");
                            continue;
                    }
                    break;
                }
            }
            Console.WriteLine("Game successfully created!");

        }
        public void ShowInfo()
        {
            Console.WriteLine("Play game");
        }
    }
}

using Lab3.GameAccounts;
using Lab3.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI
{
    public class CreateGameAccountCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        public CreateGameAccountCommand(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            Console.Clear();
            Console.WriteLine("Enter player name:");
            var username = "" + Console.ReadLine();
            if (_accountService.GetGameAccountByUsername(username) != null)
            {
                Console.WriteLine("A player with that name already exists.");
                return;
            }
            Console.WriteLine("Enter account type:");
            while (true)
            {
                Console.WriteLine("1. Standard\n2. Bonus streak\n3. Half rating lose");
                var response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        _accountService.CreateGameAccount(AccountType.Standard, username);
                        break;
                    case "2":
                        _accountService.CreateGameAccount(AccountType.Streak, username);
                        break;
                    case "3":
                        _accountService.CreateGameAccount(AccountType.HalfLoss, username);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        continue;
                }
                break;
            }
            Console.WriteLine("Account successfully created!");

        }
        public void ShowInfo()
        {
            Console.WriteLine("Create account");
        }
    }
}

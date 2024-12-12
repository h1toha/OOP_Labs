using Lab3.Repository;
using Lab3.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI
{
    public class ReadAllAccoutsCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        public ReadAllAccoutsCommand(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            Console.Clear();
            Console.WriteLine("All players:");
            _accountService.ReadAllGameAccounts().ForEach(a => Console.Write($"Name: {a.Username},  Current rating: {a.CurrentRating}, Account type: {a.AccountType}\n"));
        }
        public void ShowInfo()
        {
            Console.WriteLine("Show all players");
        }
    }
}

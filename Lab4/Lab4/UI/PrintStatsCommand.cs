using Lab3.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI
{
    public class PrintStatsCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        public PrintStatsCommand(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            Console.Clear();
            Console.WriteLine("Enter username or id: ");
            var response = Console.ReadLine();
            if (IsNumeric(response))
            {
                _accountService.PrintStats(_accountService.GetGameAccountByID(int.Parse(response)));
            }
            else
            {
                _accountService.PrintStats(_accountService.GetGameAccountByUsername(response));
            }
        }
        private bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
        public void ShowInfo()
        {
            Console.WriteLine("Show user statistics");
        }
    }
}

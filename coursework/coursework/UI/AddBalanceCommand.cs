using coursework.Entity;
using coursework.Service.Interface;

namespace coursework.UI
{
    public class AddBalanceCommand : ICommand
    {
        private readonly IUserService _userService;
        private readonly User _currentUser;

        public AddBalanceCommand(IUserService userService, User currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Add Balance ===");
            Console.ResetColor();
            Console.Write("Amount: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount, it must be numbers.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            if (amount > 0)
            {
                _userService.AddBalance(_currentUser.Id, amount);
                Console.WriteLine($"Added {amount:C} to balance");
                Console.ReadKey();
            }
            else if (amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Amount must be greater than 0!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("3. Add Balance");
        }
    }
}

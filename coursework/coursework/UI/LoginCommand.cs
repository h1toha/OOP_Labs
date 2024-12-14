using coursework.Entity;
using coursework.Service.Interface;

namespace coursework.UI
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService _userService;
        private Action<User> _onLoginSuccess;

        public LoginCommand(IUserService userService, Action<User> onLoginSuccess)
        {
            _userService = userService;
            _onLoginSuccess = onLoginSuccess;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string? username = Console.ReadLine();
            Console.Write("Password: ");
            string? password = MaskPassword();

            if (username == null || password == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username or password cannot be empty!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            var user = _userService.Login(username, password);
            if (user != null)
            {
                _onLoginSuccess(user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid credentials!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("1. Login");
        }

        private string MaskPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return password;
        }
    }
}

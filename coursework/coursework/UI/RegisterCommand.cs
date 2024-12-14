using coursework.Service.Interface;

namespace coursework.UI
{
    public class RegisterCommand : ICommand
    {
        private readonly IUserService _userService;

        public RegisterCommand(IUserService userService)
        {
            _userService = userService;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("Username: ");
            string? username = Console.ReadLine();
            Console.Write("Password: ");
            string? password = MaskPassword();
            Console.Write("Confirm Password: ");
            string? confirmPassword = MaskPassword();

            if (username == null || password == null || confirmPassword == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username or password cannot be empty!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            if (password != confirmPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passwords do not match!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
            if (_userService.Register(username, passwordHash))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registration successful!");
                Console.WriteLine("Please login to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("2. Register");
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

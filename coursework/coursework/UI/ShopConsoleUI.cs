using coursework.Entity;
using coursework.Service.Interface;

namespace coursework.UI
{
    public class ShopConsoleUI
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private User _currentUser;
        private bool _isRunning = true;

        public ShopConsoleUI(IUserService userService, IProductService productService, IOrderService orderService)
        {
            _userService = userService;
            _productService = productService;
            _orderService = orderService;
        }

        public void Start()
        {
            while (_isRunning)
            {
                if (_currentUser == null)
                {
                    ShowAuthMenu();
                }
                else
                {
                    ShowMainMenu();
                }
            }
        }

        private void ShowAuthMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== E-Shop ===");
            Console.ResetColor();
            var loginCommand = new LoginCommand(_userService, user => _currentUser = user);
            var registerCommand = new RegisterCommand(_userService);

            loginCommand.ShowInfo();
            registerCommand.ShowInfo();
            Console.WriteLine("3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    loginCommand.Execute();
                    break;
                case "2":
                    registerCommand.Execute();
                    break;
                case "3":
                    _isRunning = false;
                    break;
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Welcome, {_currentUser.Username}! Balance: {_currentUser.Balance:C}");
            Console.ResetColor();

            var showProductsCommand = new ShowProductsCommand(_productService);
            var purchaseCommand = new PurchaseProductCommand(_orderService, _productService, _currentUser);
            var addBalanceCommand = new AddBalanceCommand(_userService, _currentUser);
            var orderHistoryCommand = new ShowOrderHistoryCommand(_orderService, _currentUser);

            showProductsCommand.ShowInfo();
            purchaseCommand.ShowInfo();
            addBalanceCommand.ShowInfo();
            orderHistoryCommand.ShowInfo();
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    showProductsCommand.Execute();
                    break;
                case "2":
                    purchaseCommand.Execute();
                    break;
                case "3":
                    addBalanceCommand.Execute();
                    break;
                case "4":
                    orderHistoryCommand.Execute();
                    break;
                case "5":
                    _currentUser = null;
                    break;
                case "6":
                    _isRunning = false;
                    break;
            }
        }
    }
}

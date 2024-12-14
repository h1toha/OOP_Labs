using coursework.Entity;
using coursework.Service.Interface;

namespace coursework.UI
{
    public class PurchaseProductCommand : ICommand
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly User _currentUser;

        public PurchaseProductCommand(IOrderService orderService, IProductService productService, User currentUser)
        {
            _orderService = orderService;
            _productService = productService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Purchase Product ===");
            Console.ResetColor();
            var products = _productService.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");
            }
            Console.Write("Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid product ID!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.Write("Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid quantity!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            if (_orderService.CreateOrder(_currentUser.Id, productId, quantity) != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Purchase successful!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Purchase failed! Check your balance and product availability.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("2. Purchase Product");
        }
    }
}

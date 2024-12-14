using coursework.Entity;
using coursework.Service.Interface;

namespace coursework.UI
{
    public class ShowOrderHistoryCommand : ICommand
    {
        private readonly IOrderService _orderService;
        private readonly User _currentUser;

        public ShowOrderHistoryCommand(IOrderService orderService, User currentUser)
        {
            _orderService = orderService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Order History ===");
            Console.ResetColor();
            var orders = _orderService.GetUserOrders(_currentUser.Id);
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Product ID: {order.ProductId}, " +
                                $"Quantity: {order.Quantity}, Total: {order.TotalPrice:C}, " +
                                $"Date: {order.OrderDate}");
            }
            Console.ReadKey();
        }

        public void ShowInfo()
        {
            Console.WriteLine("4. Order History");
        }
    }
}

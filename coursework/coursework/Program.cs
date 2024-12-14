using coursework.Repository;
using coursework.Service;
using coursework.UI;

namespace coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            var dbContext = new DbContext();

            var userRepo = new UserRepository(dbContext);
            var productRepo = new ProductRepository(dbContext);
            var orderRepo = new OrderRepository(dbContext);

            var userService = new UserService(userRepo);
            var productService = new ProductService(productRepo);
            var orderService = new OrderService(orderRepo, productRepo, userRepo);

            productService.CreateProduct("Laptop", 40000, 10);
            productService.CreateProduct("Mouse", 700, 20);
            productService.CreateProduct("Keyboard", 2000, 30);
            productService.CreateProduct("Monitor", 10000, 15);
            productService.CreateProduct("Headphones", 1500, 25);
            productService.CreateProduct("Webcam", 3000, 5);


            var ui = new ShopConsoleUI(userService, productService, orderService);
            ui.Start();
        }
    }
}
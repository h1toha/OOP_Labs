using coursework.Service.Interface;

namespace coursework.UI
{
    public class ShowProductsCommand : ICommand
    {
        private readonly IProductService _productService;

        public ShowProductsCommand(IProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Products ===");
            Console.ResetColor();
            var products = _productService.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");
            }
            Console.ReadKey();
        }

        public void ShowInfo()
        {
            Console.WriteLine("1. View Products");
        }
    }
}

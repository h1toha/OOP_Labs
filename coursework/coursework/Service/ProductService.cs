using coursework.Entity;
using coursework.Repository.Interface;
using coursework.Service.Interface;

namespace coursework.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product CreateProduct(string name, decimal price, int stock)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || stock < 0)
                return null;

            var product = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            return _productRepository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null || product.Price < 0 || product.Stock < 0)
                return;

            var existingProduct = _productRepository.GetById(product.Id);
            if (existingProduct == null)
                return;

            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return;

            _productRepository.Delete(id);
        }

        public void UpdateStock(int productId, int quantity)
        {
            var product = _productRepository.GetById(productId);
            if (product == null || quantity < 0)
                return;

            product.Stock = quantity;
            _productRepository.Update(product);
        }
    }
}

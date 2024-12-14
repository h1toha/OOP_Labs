using coursework.Entity;
using coursework.Repository.Interface;

namespace coursework.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            product.Id = _context.Products.Count + 1;
            _context.Products.Add(product);
            return product;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _context.Products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
        }

        public void UpdateStock(int productId, int newStock)
        {
            var product = GetById(productId);
            if (product != null)
            {
                product.Stock = newStock;
                Update(product);
            }
        }
    }
}

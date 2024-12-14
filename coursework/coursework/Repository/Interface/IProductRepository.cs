using coursework.Entity;

namespace coursework.Repository.Interface
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product Create(Product product);
        void Update(Product product);
        void Delete(int id);
        void UpdateStock(int productId, int newStock);
    }
}

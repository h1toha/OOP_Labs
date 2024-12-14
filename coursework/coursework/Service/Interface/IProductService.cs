using coursework.Entity;

namespace coursework.Service.Interface
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product CreateProduct(string name, decimal price, int stock);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void UpdateStock(int productId, int quantity);
    }
}

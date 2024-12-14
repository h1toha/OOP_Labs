using coursework.Entity;

namespace coursework.Repository.Interface
{
    public interface IOrderRepository
    {
        Order GetById(int id);
        List<Order> GetAll();
        Order Create(Order order);
        void Update(Order order);
        void Delete(int id);
        List<Order> GetByUserId(int userId);
    }
}

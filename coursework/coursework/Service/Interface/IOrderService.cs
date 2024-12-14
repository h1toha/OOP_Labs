using coursework.Entity;

namespace coursework.Service.Interface
{
    public interface IOrderService
    {
        Order GetById(int id);
        List<Order> GetAll();
        Order CreateOrder(int userId, int productId, int quantity);
        List<Order> GetUserOrders(int userId);
        void CancelOrder(int orderId);
    }
}

using coursework.Entity;
using coursework.Repository.Interface;

namespace coursework.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            order.Id = _context.Orders.Count + 1;
            _context.Orders.Add(order);
            return order;
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
                _context.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }

        public void Update(Order order)
        {
            var existingOrder = GetById(order.Id);
            if (existingOrder != null)
            {
                existingOrder.UserId = order.UserId;
                existingOrder.ProductId = order.ProductId;
                existingOrder.Quantity = order.Quantity;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalPrice = order.TotalPrice;
            }
        }
    }
}

using coursework.Entity;
using coursework.Repository.Interface;
using coursework.Service.Interface;

namespace coursework.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order CreateOrder(int userId, int productId, int quantity)
        {
            var user = _userRepository.GetById(userId);
            var product = _productRepository.GetById(productId);

            if (user == null || product == null ||
                quantity <= 0 || quantity > product.Stock ||
                user.Balance < product.Price * quantity)
                return null;

            var order = new Order
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity,
                OrderDate = DateTime.Now,
                TotalPrice = product.Price * quantity
            };

            product.Stock -= quantity;
            _productRepository.Update(product);

            user.Balance -= order.TotalPrice;
            _userRepository.Update(user);

            return _orderRepository.Create(order);
        }

        public List<Order> GetUserOrders(int userId)
        {
            return _orderRepository.GetByUserId(userId);
        }

        public void CancelOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                return;

            var product = _productRepository.GetById(order.ProductId);
            var user = _userRepository.GetById(order.UserId);

            if (product == null || user == null)
                return;

            product.Stock += order.Quantity;
            _productRepository.Update(product);

            user.Balance += order.TotalPrice;
            _userRepository.Update(user);

            _orderRepository.Delete(orderId);
        }
    }
}

using coursework.Entity;

namespace coursework
{
    public class DbContext
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public DbContext()
        {
            Users = new List<User>();
            Products = new List<Product>();
            Orders = new List<Order>();
        }

    }
}

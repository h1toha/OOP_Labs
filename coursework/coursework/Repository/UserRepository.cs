using coursework.Entity;
using coursework.Repository.Interface;

namespace coursework.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            user.Id = _context.Users.Count + 1;
            _context.Users.Add(user);
            return user;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Balance = user.Balance;
                existingUser.Password = user.Password;
            }
        }
    }
}

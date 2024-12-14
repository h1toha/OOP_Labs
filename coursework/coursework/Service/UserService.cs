using coursework.Entity;
using coursework.Repository.Interface;
using coursework.Service.Interface;

namespace coursework.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool Register(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            if (_userRepository.GetByUsername(username) != null)
                return false;

            var user = new User
            {
                Username = username,
                Password = password,
                Balance = 0
            };

            return _userRepository.Create(user) != null;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _userRepository.GetByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
                return user;
            return null;
        }

        public void AddBalance(int userId, decimal amount)
        {
            if (amount <= 0)
                return;

            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                user.Balance += amount;
                _userRepository.Update(user);
            }
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                return;

            var existingUser = _userRepository.GetById(user.Id);
            if (existingUser == null)
                return;

            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return;

            _userRepository.Delete(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }
    }
}

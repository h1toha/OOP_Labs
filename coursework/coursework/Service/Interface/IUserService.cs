using coursework.Entity;

namespace coursework.Service.Interface
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(string username, string password);
        User Login(string username, string password);
        void AddBalance(int userId, decimal amount);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetByUsername(string username);
    }
}

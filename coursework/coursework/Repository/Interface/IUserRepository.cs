using coursework.Entity;

namespace coursework.Repository.Interface
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        User Create(User user);
        void Update(User user);
        void Delete(int id);
        User GetByUsername(string username);
    }
}

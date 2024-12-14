
namespace coursework.Entity
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public decimal Balance { get; set; }
    }
}

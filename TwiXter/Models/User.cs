using TwiXter.RequestModels;

namespace TwiXter.Models
{
    public class User
    {
        public User() { }
        public User(string login, string email,string password)
        {
            Login = login;
            Email = email;
            PasswordHash = Helpers.HashHelper.ToHash(password);
        }
        public User(RegisterRequest request)
        {
            Login = request.Login;
            Email = request.Email;
            PasswordHash = Helpers.HashHelper.ToHash(request.Password);
        }
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}

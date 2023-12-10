using TwiXter.RequestModels;

namespace TwiXter.Models
{
    public class User
    {
        public User() { }

        public User(RegisterRequest request)
        {
            Login = request.Login;
            Email = request.Email;
            PasswordHash = Helpers.HashHelper.ToHash(request.Password);
            CreateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

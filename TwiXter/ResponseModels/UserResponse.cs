using TwiXter.Helpers;
using TwiXter.Models;

namespace TwiXter.ResponseModels
{
    public class UserResponse
    {
        public UserResponse(User user) {
            Login = user.Login;
            Token = JWTGenerator.GenerateToken(user.Login);
        }
        public string? Login { get; set; }
        public string? Token { get; set; }
    }
}

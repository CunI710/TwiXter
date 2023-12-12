using TwiXter.Helpers;
using TwiXter.Models;

namespace TwiXter.ResponseModels
{
    public class UserResponse
    {
        public UserResponse(User user) {
            Login = user.Login;
            Email = user.Email;
            Token = JWTGenerator.GenerateToken(user.Login,user.Email);
            
        }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }  
    }
}

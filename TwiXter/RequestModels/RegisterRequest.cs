using System.Runtime.CompilerServices;

namespace TwiXter.RequestModels
{
    public class RegisterRequest
    {
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TwiXter.Helpers;
using TwiXter.Models;
using TwiXter.RequestModels;
using TwiXter.ResponseModels;

namespace TwiXter.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("register")]
        public IActionResult Create(RegisterRequest register, ApplicationContext db)
        {
            User? user = db.Users.FirstOrDefault(t => t.Email == register.Email);

            if (user != null)
            {
                return BadRequest(new { message = "Уже есть такой" });
            }

            user = new User(register);
            db.Add(user);
            db.SaveChanges();

            return Ok(new UserResponse(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest login,ApplicationContext db)
        {
            User? user = db.Users.FirstOrDefault(u => u.Email == login.Email && u.PasswordHash == HashHelper.ToHash(login.Password));
            if(user == null)
            {
                return BadRequest(new { message = "пользователь не найден" });
            }
            return Ok(new UserResponse(user));
        }

        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll(ApplicationContext db)
        {
            var users = db.Users.ToList();
            return Ok(users);
        }

    }

}

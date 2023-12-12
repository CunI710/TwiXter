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
                return BadRequest(new { message = "Пользователь с такой почтой уже существует" });
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
                return BadRequest(new { message = "Почта или пароль введены неправильно" });
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


    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        [Authorize]
        [HttpPost("create")]
        public IActionResult Create(CommentRequest commentRequest,ApplicationContext db)
        {
            User? user = db.Users.FirstOrDefault(u => u.Email == commentRequest.UserEmail);
            if (user == null)   return NotFound();

            Comment comment = new Comment(commentRequest,user);
            db.Comments.Add(comment);
            db.SaveChanges();

            string? baseUserLogin = null;
            if (commentRequest.BaseCommentId != null)
            {
                Comment? baseComment = db.Comments.FirstOrDefault(c => c.Id == commentRequest.BaseCommentId);
                User? baseUser = db.Users.FirstOrDefault(u => u.Id == baseComment!.UserId);
                baseUserLogin = baseUser.Login;
            }

            CommentResponse commentResponse = new CommentResponse(comment, baseUserLogin);

            return Ok(commentResponse);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(ApplicationContext db)
        {

            List<Comment> comments = (from c in db.Comments.ToList()
                                     join u in db.Users.ToList() on c.User.Id equals u.Id
                                     select c).ToList();
            List<CommentResponse> response = comments.Select(c=>new CommentResponse(c)).ToList();

            response.ForEach(c => {
                var result = response.Where(t => t.BaseCommentId == c.Id).ToList();
                result.ForEach(r => r.BaseUserLogin = c.UserLogin);
                c.SubComments = result;
            });


            return Ok(response.Where(r=>r.BaseCommentId==null));
        }

    }

}

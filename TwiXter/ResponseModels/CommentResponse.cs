using TwiXter.Models;
namespace TwiXter.ResponseModels
{
    public class CommentResponse
    {

        public CommentResponse(Comment comment,string? baseUserLogin) { 
            Id = comment.Id;
            Text = comment.Text;
            UserLogin = comment.User.Login;
            BaseUserLogin = baseUserLogin;
            CreateDate = comment.CreateDate;
        }
        public CommentResponse(Comment comment) { 
            Id = comment.Id;
            Text = comment.Text;
            UserLogin = comment.User.Login;
            BaseCommentId = comment.BaseCommentId;
            CreateDate = comment.CreateDate;
        }

        public int Id { get; set; } 
        public string UserLogin { get; set; }
        public int? BaseCommentId {  get; set; }
        public string? BaseUserLogin { get; set; }
        public string Text { get; set; }
        public List<CommentResponse>? SubComments { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}


//
//
//
//      id userName BaseUserName Text subComments=null
//
//
//
//
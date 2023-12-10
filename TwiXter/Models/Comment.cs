using TwiXter.RequestModels;
namespace TwiXter.Models
{
    public class Comment
    {
        public Comment() { }
        public Comment(CommentRequest comment,User user) { 
            
            Text = comment.Text;
            BaseCommentId = comment.BaseCommentId;
            User = user;
            CreateDate = DateTime.Now;

        }
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? BaseCommentId {  get; set; }
        public  DateTime CreateDate { get; set; }
    }
}

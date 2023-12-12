namespace TwiXter.RequestModels
{
    public class CommentRequest
    {
        public int? BaseCommentId {  get; set; }
        public string UserEmail { get; set; }

        public string Text { get; set; }

    }
}   

namespace Model
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
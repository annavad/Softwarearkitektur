namespace Model
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
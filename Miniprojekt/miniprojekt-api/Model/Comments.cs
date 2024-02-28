namespace Model
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public Users User { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
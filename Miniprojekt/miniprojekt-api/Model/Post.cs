namespace Model
{
    public class Post
    {
        public int PostId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }

        public List<Comment> Comments { get; set; }
        public DateTime PostDate { get; set; }
    }
}
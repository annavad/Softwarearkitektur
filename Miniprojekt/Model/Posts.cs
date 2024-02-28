namespace Model
{
    public class Posts
    {
        public int PostId { get; set; }
        public User User { get; set; }
        public List<Comments> Comments { get; set; }
        public DateTime PostDate { get; set; }
    }
}
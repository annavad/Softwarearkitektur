namespace Model
{
    public class Posts
    {
        public int PostId { get; set; }
        public Users User { get; set; }
        public string Post { get; set; }

        public List<Comments> Comments { get; set; }
        public DateTime PostDate { get; set; }
    }
}
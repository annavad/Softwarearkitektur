namespace Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public User(string username = "") {
        Name = username;
    }
    public User() {
        UserId = 0;
        Name = "";
    }
    }
}
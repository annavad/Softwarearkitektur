using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using Model;

namespace Service;

public class DataService
{
    private PostContext db { get; }

    public DataService(PostContext db) {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData() {
        
        User user = db.User.FirstOrDefault()!;
        if (user == null) {
            user = new User { Name = "Kristian" };
            db.User.Add(user);
            db.User.Add(new User { Name = "Søren" });
            db.User.Add(new User { Name = "Mette" });
        }

        Post post = db.Post.FirstOrDefault()!;
        if (post == null)
        {
            db.Post.Add(new Post { Content = "Her er et post", User = user });
            db.Post.Add(new Post { Content = "Test-post til folket", User = user });
            db.Post.Add(new Post { Content = "Vi poster lige en tester", User = user });
        }

        db.SaveChanges();
    }

    public List<Post> GetPosts() {
        return db.Post.Include(p => p.User).ToList();
    }

    public Post GetPost(int id) {
        return db.Post.Include(p => p.User).FirstOrDefault(p => p.PostId == id)!;
    }
    
    public Post CreatePost(Post post)
    {
        db.Post!.Add(post);
        db.SaveChanges();
        return post;
    }

     public Comment CreateComment(Comment comment, int postId)
    {
        var post = db.Post.Find(postId);
        post.Comments.Add(comment);
        db.SaveChanges();
        return comment;
    }
    public User GetUser(int id) {
        return db.User.FirstOrDefault(u => u.UserId == id)!;
    }

    /*public Book GetBook(int id) {
        return db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
    }

    public string CreatePost(User user, string title = "", string content = "", int upvotes = 0, int downvotes = 0) {
        User User = db.User.FirstOrDefault(u => u.User == );
        db.Post.Add(new Post { Title = title, User = user });
        db.SaveChanges();
        return "Post created";
    }
    public List<Author> GetAuthors() {
        return db.Authors.ToList();
    }
    */
}
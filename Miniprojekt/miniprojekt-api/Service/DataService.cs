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

    public Post PostUpvote(int id)
    {
        var post = db.Post!.FirstOrDefault(p => p.PostId == id);
        post!.Upvotes ++;
        db.SaveChanges();
        return post;
    }

    public Post PostDownvote(int id)
    {
        var post = db.Post!.FirstOrDefault(p => p.PostId == id);
        post!.Downvotes ++;
        db.SaveChanges();
        return post;
    }
}
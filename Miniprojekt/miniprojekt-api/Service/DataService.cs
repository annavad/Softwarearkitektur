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
            db.Post.Add(new Post { Text = "Her er et post", User = user });
            db.Post.Add(new Post { Text = "Test-post til folket", User = user });
            db.Post.Add(new Post { Text = "Vi poster lige en tester", User = user });
        }

        db.SaveChanges();
    }

    public List<Post> GetPosts() {
        return db.Post.Include(p => p.User).ToList();
    }

    /*public Book GetBook(int id) {
        return db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
    }

    public List<Author> GetAuthors() {
        return db.Authors.ToList();
    }

    public Author GetAuthor(int id) {
        return db.Authors.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == id);
    }

    public string CreateBook(string title, int authorId) {
        Author author = db.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        db.Books.Add(new Book { Title = title, Author = author });
        db.SaveChanges();
        return "Book created";
    }*/

}
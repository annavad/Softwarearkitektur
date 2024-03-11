using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Service;
using Model;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



// Tilføj DbContext factory som service.
builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();

// Dette kode kan bruges til at fjerne "cykler" i JSON objekterne.
/*
builder.Services.Configure<JsonOptions>(options =>
{
    // Her kan man fjerne fejl der opstår, når man returnerer JSON med objekter,
    // der refererer til hinanden i en cykel.
    // (altså dobbelrettede associeringer)
    options.SerializerOptions.ReferenceHandler = 
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
*/
var app = builder.Build();

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}

app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});


// DataService fås via "Dependency Injection" (DI)
app.MapGet("/", (DataService service) =>
{
    return new { message = "Welcome everybody to my videooooos!" };
});

app.MapGet("/api/posts", (DataService service) =>
{
    return service.GetPosts().Select(p => new { 
        postId = p.PostId, 
        Post = p.Content,
        Comment = p.Comments, 
        user = new {
            p.User.UserId, p.User.Name
        } 
    });
});

app.MapGet("/api/posts/{id}", (DataService service, int id) => 
{
    return service.GetPost(id);
});

app.MapPost("/api/posts", (DataService service, NewPostData data) =>
{
    User user = service.GetUser(data.UserId);
    Post post = new Post(user, data.Title, data.Content);
    return service.CreatePost(post);
});

app.MapPost("/api/posts/{id}/comments", (DataService service, NewCommentData data, int id) => 
{
    User user = service.GetUser(data.UserId);
    Comment comment = new Comment(user, data.Content);
    return service.CreateComment(comment, id);
});

app.MapPut("/api/posts/{id}/upvote/", (DataService service, int id) =>
{
    var upvotedPost = service.PostUpvote(id);
    return Results.Ok(upvotedPost);
});

app.MapPut("/api/posts/{id}/downvote/", (DataService service, int id) =>
{
    var downvotedPost = service.PostDownvote(id);
    return Results.Ok(downvotedPost);
});

app.Run();


record NewPostData(string Title, string Content, int UserId);
record NewCommentData(string Content, int UserId);


//Alle nødvendige routes til projektet
//app.MapGet("/posts/",);
//app.MapGet("/posts/{id}",);
//app.MapPost("/posts/", );
//app.MapPost("/posts/{id}/comments", );
//app.MapPut("/posts/{id}/upvote", );
//app.MapPut("/posts/{id}/comments/{commentId}/upvote");
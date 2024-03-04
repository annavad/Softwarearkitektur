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
    return new { message = "Hello World!" };
});

app.MapGet("/api/posts", (DataService service) =>
{
    return service.GetPosts().Select(p => new { 
        postId = p.PostId, 
        Post = p.Text, 
        user = new {
            p.User.UserId, p.User.Name
        } 
    });
});

/*app.MapGet("/api/authors", (DataService service) =>
{
    return service.GetAuthors().Select(a => new { a.AuthorId, a.Fullname });
});

app.MapGet("/api/posts/{id}", (DataService service, int id) => 
{
    return service.GetPost(id);
});

app.MapPost("/api/posts", (DataService service, NewPostData data) =>
{
    string result = service.CreatePost(data.Post, data.UserId);
    return new { message = result };
});

app.MapPost("/api/posts/{id}/comments", (DataService service, NewCommentData data) => 
{
    string result = service.CreateComment(data.Comment, data.UserId);
    return new { message = result};
});
*/


app.Run();

record NewPostData(string Post, int UserId);

//Alle nødvendige routes til projektet
//app.MapGet("/posts/",);
//app.MapGet("/posts/{id}",);
//app.MapPost("/posts/", );
//app.MapPost("/posts/{id}/comments", );
//app.MapPut("/posts/{id}/upvote", );
//app.MapPut("/posts/{id}/comments/{commentId}/upvote");
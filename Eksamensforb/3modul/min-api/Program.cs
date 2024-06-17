var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//opgave 2
app.MapGet("/api/hello/", () => new { Message = "Hello world!" });

//opgave 3
app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!"});

app.MapGet("/api/hello/{name}/{age}", (string name, string age) => new { Message = $"Hello {name}, {age}!"});

app.Run();

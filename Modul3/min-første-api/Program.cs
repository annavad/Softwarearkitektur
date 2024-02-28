var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/hello/{name}/{age}", (string name, string age) => new {Message = $"Hello {name}, {age}!"});

app.Run();

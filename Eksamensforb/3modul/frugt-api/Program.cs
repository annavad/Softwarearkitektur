var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Brug List<string> i stedet for string[]
List<string> frugter = new List<string>
{
    "æble", "banan", "pære", "ananas"
};

app.MapGet("/api/frugt/", () => frugter);

app.MapGet("/api/frugt/{index}/", (int index) => 
{
    if (index < 0 || index >= frugter.Count)
    {
        return Results.NotFound(new { Message = "Frugt ikke fundet" });
    }
    return Results.Ok(frugter[index]);
});

app.MapGet("/api/frugt/random/", () => frugter[new Random().Next(frugter.Count)]);

// Opgave 5: Tilføj en ny frugt til listen
app.MapPost("/api/frugt/{newFrugt}", (string newFrugt) =>
{
    frugter.Add(newFrugt);
    Console.WriteLine($"Tilføjet frugt: {newFrugt}");
    return Results.Ok(frugter);
});

app.Run();

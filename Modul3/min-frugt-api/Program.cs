var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

//Opg4
app.MapGet("/api/frugt", () => frugter);
app.MapGet("/api/frugt/{index}", (int index) => frugter [index]);
app.MapGet("/api/frugt/random", () => frugter[new Random().Next(frugter.Length)]); 

//Opg5 Ikke færdig
app.MapPost("/api/frugt/{newFrugt}", (string newFrugt) => 
{
    var 

Console.Writeline($"Tilføjet frugt: {frugter name}")
return
})

app.Run();

var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

kunde[] kunder = new kunde[]
{
    new kunde(0, "Birgitte Wagner", "bgitte@hotmail.dk", "privat"),
    new kunde(1, "Simon Thyesen", "ST@gmail.com", "privat"),
    new kunde(2, "Tine Madsen", "tinemadsen@maersk.dk", "erhverv")
};


//Henter hele arrayet med kunder
app.MapGet("/api/kunder", () => kunder);

//Henter den specifikke kunde, hvis id du skriver i stien
app.MapGet("/api/kunder/{id}", (int id) => kunder [id]);

//Lader mig tilføje en ny kunde i body
app.MapPost("/api/kunder", (kunde newKunde) => {
   kunder = kunder.Append(newKunde).ToArray();  
});

//Sletter en kunde fra arrayet
app.MapDelete("/api/kunder/{id}", (int id) => {
    kunder = kunder.Where((kunde, index) => index != id).ToArray();
        return Results.NoContent();
});

//Henter en liste af emails baseret på kundetypen (ikke færdig)
//app.MapGet("/api/emails/{type}", (string type) => kunder {
//       return kunder.Where;

app.Run();

record kunde(int id, string navn, string email, string type);
public class kunde {
    public int id { get; set; }
    public string navn { get; set;}
    public string email { get; set;}
    public string type { get; set; }
}
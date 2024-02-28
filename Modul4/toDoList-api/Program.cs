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

toDoTask[] tasks = new toDoTask[]
{
    new toDoTask(0, "gør rent", false),
    new toDoTask(1, "lufte hund", true),
    new toDoTask(2, "lave kode-lektier", false)
};

//Printer bare teksten "Todo liste"
app.MapGet("/", () => "Todo liste");

//Viser hele arrayet med tasks
app.MapGet("/api/tasks", () => tasks);

//Viser den specifikket task, hvis id(samme som index i arrayet) du skriver i stien
app.MapGet("/api/tasks/{id}", (int id) => tasks [id]);

//Gør det muligt at ændre en tast i body (udover at den kokser med Id'et..)
app.MapPut("/api/tasks/{id}", (int id, toDoTask newTask) => {
    tasks [id] = newTask;
});

//Sletter en task fra arrayet
app.MapDelete("/api/tasks/{id}", (int id) => {
    tasks = tasks.Where((task, index) => index != id).ToArray();
        return Results.NoContent();
});

//Lader mig tilføje en ny task i body
app.MapPost("/api/tasks", (toDoTask newTask) => {
   tasks = tasks.Append(newTask).ToArray();  
});

app.Run();

record toDoTask(int id, string text, bool done);
record toDoSimpleTask(string text, bool done);

  
// tasks = tasks.Append(newTask).ToArray();  
 //int newIndex = tasks.Length; 
    
   // tasks[newIndex] = newTask; {newIndex++;}
    //    return Results.Created($"/api/tasks/{newIndex}", newTask);
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Model;

using (var db = new boardContext()) 
{
    
    
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Indsæt et nyt task");
    db.Add(new Todos());
    db.SaveChanges();

    // Read
    //Console.WriteLine("Find det sidste task");
    //var lastTask = db.Todos
     //   .OrderBy(b => b.TodoTaskId)
      //  .Last();
    //Console.WriteLine($"Text: {lastTask.Text}");
}


// var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
// var AllowSomeStuff = "_AllowSomeStuff";
//builder.Services.AddCors(options =>
//{
   // options.AddPolicy(name: AllowSomeStuff, builder => {
      //  builder.AllowAnyOrigin()
      //         .AllowAnyHeader()
       //        .AllowAnyMethod();
  //  });
//});

// Tilføj DbContext factory som service.
//builder.Services.AddDbContext<boardContext>(options =>
 //   options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
// builder.Services.AddScoped<DataService>();
﻿using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Indsæt et nyt task");
    db.Add(new TodoTask("En opgave der skal løses", false));
    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");

    // Update ikke færdig, så hele koden kan ikke Build lige nu
    var testTask = lastTask;
    testTask.Text = "Bedre opgave";
    db.SaveChanges

    // Delete

}
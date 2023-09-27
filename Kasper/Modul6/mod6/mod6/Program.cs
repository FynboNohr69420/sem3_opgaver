using Model;
using System;
using System.Xml.Linq;

using (var db = new TaskContext())
{

    {
        // Create the database (if not exists)
        db.Database.EnsureCreated();

        // Create a new board
        var newBoard = new Board();
        db.Boards.Add(newBoard);

        // Create multiple tasks for the board
        var task1 = new Todo
        {
            Name = "Task 3",
            Category = "To Do",
            Board = newBoard // Set the board for this task
        };
        db.Todos.Add(task1);

        var task2 = new Todo
        {
            Name = "Task 4",
            Category = "In Progress",
            Board = newBoard // Set the board for this task
        };
        db.Todos.Add(task2);

        // Save changes to the database
        db.SaveChanges();

        Console.WriteLine("Data inserted successfully.");


        /*
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Indsætter i DB");
        db.Add(new TodoTask("Jeg hedder Kasper", "navn", false));
        db.SaveChanges();

        // Read
        Console.WriteLine("Find det sidste task");
        var lastTask = db.Tasks
            .OrderBy(b => b.TodoTaskId)
            .Last();
        Console.WriteLine($"Text: {lastTask.Text}");

        // Update
        Console.WriteLine("Update en task");
        var blog = db.Tasks.Single(b => b.Text == "Jeg hedder Jens");
        blog.Text = "http://example.com/blog";
        db.SaveChanges();
        Console.WriteLine("Update gemt");

        // Delete
        Console.WriteLine("Delete en task");
        var deleteTask = db.Tasks.Single(b => b.Text == "http://example.com/blog");
        db.Tasks.Remove(deleteTask);
        db.SaveChanges();
        Console.WriteLine("Update gemt");
        */
    }
}
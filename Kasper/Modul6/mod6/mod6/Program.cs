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

        var newUser = new User("Kasper");
        db.Users.Add(newUser);

        // Create multiple tasks for the board
        var task1 = new Todo
        {
            Name = "Task 3",
            Category = "To Do",
            Board = newBoard, // Set the board for this task
            User = newUser
        };
        db.Todos.Add(task1);

        var task2 = new Todo
        {
            Name = "Task 4",
            Category = "In Progress",
            Board = newBoard, // Set the board for this task
            User = newUser
        };
        db.Todos.Add(task2);

        // Save changes to the database
        db.SaveChanges();

        Console.WriteLine("Data inserted successfully.");

        //Næste opgave se slide 10 (Samling af columns)
    }
}
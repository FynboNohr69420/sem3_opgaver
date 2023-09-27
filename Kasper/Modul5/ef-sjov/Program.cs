using Model;

using (var db = new TaskContext())
{

    // Create
    Console.WriteLine("Indsætter i DB");
    db.Add(new TodoTask("Puds spejle", "Task", false, new User("Palle")));
    db.SaveChanges();

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
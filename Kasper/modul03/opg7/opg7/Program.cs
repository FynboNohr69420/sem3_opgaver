/*namespace opg7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}*/

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

app.MapGet("/", () => new { Message = "Hello world!!" });

app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}, {age}!" });

List<Todo> tasks = new List<Todo>();

app.MapGet("/", () => Results.StatusCode(405));

app.MapGet("/api/tasks", () =>
{
    return tasks;
}
);

app.MapGet("/api/tasks/{id}", (int id) =>
{
    return tasks[id];
}
);



app.MapPost("/api/tasks", (Todo todo) =>
{
    tasks.Add(todo);
    return tasks;
});

app.MapPut("/api/tasks/{id}", (int id, Todo task) =>
{
    tasks[id] = task;
    return tasks[id];
}
    );

app.MapDelete("/api/tasks/{id}", (int id) =>
{

    tasks.RemoveAt(id);
}
    );



app.Run();


record Fruit(string name);
record Todo(string text, bool done);


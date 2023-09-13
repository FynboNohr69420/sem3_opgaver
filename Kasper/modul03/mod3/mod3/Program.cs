/* JAKOB OPGAVER
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

String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

app.MapGet("/api/fruits/{index}", (HttpContext context, int index) =>
{
    if (index >= 0 && index < frugter.Length)
    {
        return frugter[index];
    }
    else
    {
        context.Response.StatusCode = 400; // Set HTTP 400 status code
        return "Ugyldigt frugtindeks.";
    }
});

app.MapGet("/api/fruits/random", () => new { Message = frugter[new Random().Next(0, frugter.Length)] });

var fruits = new List<Fruit>();


app.MapPost("/api/fruitadd/{fruitName}", (string fruitName) =>
{

    var fruit = new Fruit(fruitName);

    fruits.Add(fruit);

    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

    return Results.Json(fruits);


});

//app.MapPost("/api/fruitadd/{fruitName}", (Fruit name) =>
//{

//    var fruit = new Fruit(fruit.name);

//    fruits.Append(fruit);

//    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

//    return Results.Json(fruits);


//});

app.Run();


record Fruit(string name);

*/

// MINE SVAR




var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var dogs = new List<Dog>();

app.MapGet("/", () => "Välkommen till Hunddagiset!");

app.MapGet("/dogs", () =>
{
    return Results.Ok(dogs);
});

app.MapGet("/dogs/{index}", (int index) =>
{
    if (index >= 0 && index < dogs.Count)
    {
        return Results.Ok(dogs[index]);
    }
    return Results.NotFound($"Ingen hund hittades på plats {index}");
});

app.MapPost("/dogs", (Dog dog) =>
{
    dogs.Add(dog);
    return Results.Created($"/dogs/{dogs.Count - 1}", dog);
});

app.Run();

public record Dog(string Name, int Age, string Breed);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "hi, peace in this server!");

app.MapGet("/about", () => "this is moi pervii ASP.NET Core server");

app.MapGet("/time", () => $"Time na servere: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"hi, {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum = {a + b}");

app.MapGet("/student", () => new {
    name = "Gena",
    group = "ISP - 231",
    year = 3,
    IsActive = true
});

app.MapGet("/subjects", () => new[] {
    1,
    2,
    3,
    4
});
app.Run();

app.MapGet("/product/{Id}", (int id) => new Product(
    Id: id,
    Name: $"Товар #{id}",
    Price: id * 99.99m,
    InStock: id % 2 == 0
));
record Product(int Id, string Name, decimal Price, bool InStock);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "hi, peace in this server!");

app.MapGet("/about", () => "this is moi pervii ASP.NET Core server");

app.MapGet("/time", () => $"Time na servere: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"hi, {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum = {a + b}");

app.Run();

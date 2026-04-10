using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"->{method}{path}");
    await next(context);
});

app.MapGet("/", () => Results.Ok(new {
    Message = "Добро пожаловать!",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));

app.MapGet("/me", () => Results.Ok(new {
    Name = "Никифоров Тимофей",
    Group = "ИСП-231",
    Course = 3,
    Skills = new[] { "C#", "HTML", "CSS", "JS", "ASP.NET" }
}));

app.MapGet("/calc/{a}/{b}", (double a, double b) => Results.Ok(new {
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));

app.MapFallback(() => Results.NotFound(new {
    Error = "Маршрут не найден",
    Code = 404
}));
// app.Use(async (context, next) => {
//     Console.WriteLine($"[LOG]{context.Request.Method}{context.Request.Path}");
//     await next(context);
//     Console.WriteLine($"[LOG] Ответ отправлен: {context.Response.StatusCode}");
// });

// app.Use(async (context, next) => {
//     context.Response.Headers.Append("X-Powered-By", "ASP.NET Core Lab27");
//     await next(context);
// });

// app.MapGet("/", () => "hi, peace in this server!");

// app.MapGet("/about", () => "this is moi pervii ASP.NET Core server");

// app.MapGet("/time", () => $"Time na servere: {DateTime.Now}");

// app.MapGet("/hello/{name}", (string name) => $"hi, {name}!");

// app.MapGet("/sum/{a}/{b}", (int a, int b) => $"sum = {a + b}");

// app.MapGet("/student", () => new {
//     name = "Gena",
//     group = "ISP - 231",
//     year = 3,
//     IsActive = true
// });

// app.MapGet("/subjects", () => new[] {
//     1,
//     2,
//     3,
//     4
// });


// app.MapGet("/product/{id}", (int id) => new Product(
//     Id: id,
//     Name: $"Товар #{id}",
//     Price: id * 99.99m,
//     InStock: id % 2 == 0
// ));
app.Run();
// record Product(int Id, string Name, decimal Price, bool InStock);

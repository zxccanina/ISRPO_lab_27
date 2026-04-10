var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привет от ИСП-231! Авторы: zxccanina , M4R4 ");

app.Run();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List

app.MapGet("/", () => "Hello World!");

app.Run();

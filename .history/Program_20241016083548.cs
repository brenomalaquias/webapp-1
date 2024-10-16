var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<NewDto> 

app.MapGet("/", () => "Hello World!");

app.Run();

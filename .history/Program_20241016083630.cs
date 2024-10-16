var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<NewDto> games = [
    
];

app.MapGet("/", () => "Hello World!");

app.Run();

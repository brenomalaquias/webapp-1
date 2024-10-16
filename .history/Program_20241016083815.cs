using webapp_1.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<NewDto> games = [
 new(1,"Mortal Kombat","fighting",20.00,new DateOnly(2000,4,5))
];

app.MapGet("/", () => "Hello World!");

app.Run();

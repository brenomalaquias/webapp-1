using webapp_1.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<NewDto> games = [
 new(1,"Mortal Kombat","fighting",20.00m,new DateOnly(2000,4,5)),
 new(2,"red dead 2","action-adventure",40.00m,new DateOnly(2018,6,7)),
 new(3,"dota","moba",00.00m,new DateOnly(2003,2,1))
];

//GET /games
app.MapGet("games",() => games);

//GET /games/1

app.Run();

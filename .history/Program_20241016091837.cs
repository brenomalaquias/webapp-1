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

//GET /games/id

app.MapGet("games/{id}",(int id) => games[id]);

//POST /games

app.MapPost("games",(CreateNewDto newGame) =>
{
    NewDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute()
});

app.Run();

using System;
using webapp_1.Dtos;

namespace webapp_1.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<NewDto> games = [
    new(1,"Mortal Kombat","fighting",20.00m,new DateOnly(2000,4,5)),
    new(2,"red dead 2","action-adventure",40.00m,new DateOnly(2018,6,7)),
    new(3,"dota","moba",00.00m,new DateOnly(2003,2,1))
    ];

    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        //GET /games
        group.MapGet("/",() => games);

        //GET /games/id

        group.MapGet("/{id}", (int id) => 
        {
            NewDto? game = games.Find(game => game.Id == id);
            
            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndPointName);

        //POST /games

        group.MapPost("/",(CreateNewDto newGame) =>
        {
          
            NewDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPointName, new{id = game.Id},game);
        });
        //PUT /games

        group.MapPut("/{id}",(int id, UpdateDto updateGame) => 
        {
            var index = games.FindIndex(game => game.Id == id);

            games[index] = new NewDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );

            return Results.NoContent();
        });

        //DELETE /games/1

        group.MapDelete("/{id}",(int id) => 
        {
            games.RemoveAll(games => games.Id == id);
            
            return Results.NoContent();
        });
        return group;
        
    }
}

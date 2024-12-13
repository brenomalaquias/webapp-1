using System;
using Microsoft.EntityFrameworkCore;
using webapp_1.Data;
using webapp_1.Dtos;
using webapp_1.Entities;
using webapp_1.Mapping;

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
        group.MapGet("/",(GameStoreContext dbContext) => dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToDto())
            );

        //GET /games/id

        group.MapGet("/{id}", (int id,GameStoreContext dbContext) => 
        {
            Game? game = dbContext.Games.Find(id);
            
            return game is null ? 
            Results.NotFound() : Results.Ok(game.DetailsDto());
        })
        .WithName(GetGameEndPointName);

        //POST /games

        group.MapPost("/",(CreateNewDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
           // game.Genre = dbContext.Genres.Find(newGame.GenreId);
            
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndPointName, new{id = game.Id},game.DetailsDto());
        });
        //PUT /games

        group.MapPut("/{id}",(int id, UpdateDto updateGame, GameStoreContext dbContext) => 
        {
            var existingGame = dbContext.Games.Find(id);

            if(existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).
            CurrentValues.SetValues(updateGame.ToEntity(id));
            
            dbContext.SaveChanges();

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

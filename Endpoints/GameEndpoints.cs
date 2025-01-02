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

   
    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        //GET /games
        group.MapGet("/",( async (GameStoreContext dbContext) => 
            await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToDto())
                .AsNoTracking()
                .ToListAsync())
            );

        //GET /games/id

        group.MapGet("/{id}", async (int id,GameStoreContext dbContext) => 
        {
            Game? game = await dbContext.Games.FindAsync(id);
            
            return game is null ? 
            Results.NotFound() : Results.Ok(game.DetailsDto());
        })
        .WithName(GetGameEndPointName);

        //POST /games

        group.MapPost("/", async (CreateNewDto newGame, GameStoreContext dbContext) =>
        {
            Game game =  newGame.ToEntity();
           // game.Genre = dbContext.Genres.Find(newGame.GenreId);
            
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndPointName, new{id = game.Id},game.DetailsDto());
        });
        //PUT /games

        group.MapPut("/{id}",async (int id, UpdateDto updateGame, GameStoreContext dbContext) => 
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if(existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).
            CurrentValues.SetValues(updateGame.ToEntity(id));
            
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /games/1

        group.MapDelete("/{id}", async (int id,GameStoreContext dbContext) => 
        {
          await dbContext.Games
                   .Where(game => game.Id == id)
                   .ExecuteDeleteAsync();
        });
        return group;
        
    }
}

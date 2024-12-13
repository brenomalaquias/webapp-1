using System;
using webapp_1.Dtos;
using webapp_1.Entities;

namespace webapp_1.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateNewDto game)
    {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate 

            };
    }
    public static Game ToEntity(this UpdateDto game,int id)
    {
            return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate 

            };
    }
    public static NewDto ToDto(this Game game)
    {
         return new (
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }
    public static GameDetailsDto DetailsDto(this Game game)
    {
         return new (
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }
}

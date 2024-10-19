using System;
using Microsoft.EntityFrameworkCore;
using webapp_1.Entities;

namespace webapp_1.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
: DbContext(options)
{
 
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

}

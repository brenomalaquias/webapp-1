using webapp_1.Data;
using webapp_1.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source = GameStore.db";

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGameEndpoints();


app.Run();

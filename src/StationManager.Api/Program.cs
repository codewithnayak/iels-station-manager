using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using StationManager.Api.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
// Load Kubernetes ConfigMap JSON if present
const string configMapPath = "/app/config/appsettings.json";

if (File.Exists(configMapPath))
{
    builder.Configuration.AddJsonFile(configMapPath, optional: true, reloadOnChange: true);
}

builder.Configuration.AddEnvironmentVariables();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UsePathBase("/station-manager");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

//This will change , when we move to GKE standard cluster

if (!string.IsNullOrEmpty(password))
{
    app.Logger.LogDebug(password);
    builder.Configuration["ConnectionStrings:Postgres"] =
        $"Host=postgres-dev.ielsportal.com;Port=5432;Database=stationdb;Username=ielsuser;Password={password}";
    app.Logger.LogDebug(builder.Configuration["ConnectionStrings:Postgres"]?.ToString());
}

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<StationDbContext>();
//     db.Database.Migrate();
// }
 

app.MapControllers();
app.MapHealthChecks("health");
//app.UseHttpsRedirection();
app.MapScalarApiReference();
app.Run();


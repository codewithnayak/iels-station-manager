using Scalar.AspNetCore;
using StationManager.Api.DI;

var builder = WebApplication.CreateBuilder(args);

// Load Kubernetes ConfigMap JSON if present
var configMapPath = "/app/config/appsettings.json";

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
//app.UseHttpsRedirection();
app.MapScalarApiReference();
app.Run();


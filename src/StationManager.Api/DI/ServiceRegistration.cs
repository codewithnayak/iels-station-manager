using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StationManager.Infrastructure.Repositories;

namespace StationManager.Api.DI;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services ,  IConfiguration config)
    {
        services.AddDbContext<StationDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Postgres")));

        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<IStationSequenceService, StationSequenceService>();

        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IStationService, StationService>();

        services.AddValidatorsFromAssembly(typeof(CreateStateRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(CreateStationRequestValidator).Assembly);
    }

}
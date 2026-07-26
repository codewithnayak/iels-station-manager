using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StationManager.Infrastructure.Repositories;

public class StationRepository : IStationRepository
{
    private readonly StationDbContext _db;

    public StationRepository(StationDbContext db)
    {
        _db = db;
    }

    public async Task<Station> AddAsync(Station station)
    {
        _db.Stations.Add(station);
        await _db.SaveChangesAsync();
        return station;
    }

    public async Task<Station?> GetByIdAsync(string stationId)
    {
        return await _db.Stations.FirstOrDefaultAsync(x => x.StationId == stationId);
    }

    public async Task<List<Station>> GetAllAsync()
    {
        return await _db.Stations.Where(x => x.IsActive).ToListAsync();
    }
}
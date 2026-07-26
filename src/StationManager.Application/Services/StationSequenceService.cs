using Microsoft.EntityFrameworkCore;

public class StationSequenceService : IStationSequenceService
{
    private readonly StationDbContext _db;

    public StationSequenceService(StationDbContext db)
    {
        _db = db;
    }

    public async Task<long> GetNextSequenceAsync(string stationId)
    {
        var year = DateTime.UtcNow.Year;

        await _db.StationSequences
            .Where(x => x.StationId == stationId && x.Year == year)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.CurrentValue, x => x.CurrentValue + 1));

        return await _db.StationSequences
            .Where(x => x.StationId == stationId && x.Year == year)
            .Select(x => x.CurrentValue)
            .FirstAsync();
    }
}
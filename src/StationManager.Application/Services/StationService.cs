using CaseManager.Domain.Entities;
using StationManager.Infrastructure.Repositories;

public class StationService : IStationService
{
    private readonly IStationRepository _repo;

    public StationService(IStationRepository repo)
    {
        _repo = repo;
    }

    public async Task<StationResponse> CreateStationAsync(CreateStationRequest request)
    {
        var station = new Station
        {
            StationId = request.StationId,
            StationCode = request.StationCode,
            StationName = request.StationName,
            StateCode = request.StateCode,
            District = request.District,
            Address = request.Address,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(station);

        return new StationResponse
        {
            StationId = station.StationId,
            StationCode = station.StationCode,
            StationName = station.StationName,
            StateCode = station.StateCode,
            District = station.District,
            Address = station.Address,
            IsActive = station.IsActive
        };
    }

    public async Task<List<StationResponse>> GetAllStationsAsync()
    {
        var stations = await _repo.GetAllAsync();

        return stations.Select(s => new StationResponse
        {
            StationId = s.StationId,
            StationCode = s.StationCode,
            StationName = s.StationName,
            StateCode = s.StateCode,
            District = s.District,
            Address = s.Address,
            IsActive = s.IsActive
        }).ToList();
    }

    public async Task<StationResponse?> GetStationByIdAsync(string stationId)
    {
        var s = await _repo.GetByIdAsync(stationId);
        if (s == null) return null;

        return new StationResponse
        {
            StationId = s.StationId,
            StationCode = s.StationCode,
            StationName = s.StationName,
            StateCode = s.StateCode,
            District = s.District,
            Address = s.Address,
            IsActive = s.IsActive
        };
    }
}

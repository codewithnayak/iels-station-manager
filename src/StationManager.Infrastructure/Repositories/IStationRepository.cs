using CaseManager.Domain.Entities;

namespace StationManager.Infrastructure.Repositories;

public interface IStationRepository
{
    Task<Station> AddAsync(Station station);
    Task<Station?> GetByIdAsync(string stationId);
    Task<List<Station>> GetAllAsync();

}
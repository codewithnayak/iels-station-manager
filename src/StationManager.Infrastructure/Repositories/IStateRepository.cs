using CaseManager.Domain.Entities;

namespace StationManager.Infrastructure.Repositories;

public interface IStateRepository
{
    Task<State> AddAsync(State state);
    Task<State?> GetByCodeAsync(string stateCode);
    Task<List<State>> GetAllAsync();
}
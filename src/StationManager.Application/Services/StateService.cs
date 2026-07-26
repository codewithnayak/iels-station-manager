using CaseManager.Domain.Entities;
using StationManager.Infrastructure.Repositories;

public class StateService : IStateService
{
    private readonly IStateRepository _repo;

    public StateService(IStateRepository repo)
    {
        _repo = repo;
    }

    public async Task<StateResponse> CreateStateAsync(CreateStateRequest request)
    {
        var state = new State
        {
            StateCode = request.StateCode,
            StateName = request.StateName,
            Country = request.Country,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(state);

        return new StateResponse
        {
            StateCode = state.StateCode,
            StateName = state.StateName,
            Country = state.Country,
            IsActive = state.IsActive
        };
    }

    public async Task<List<StateResponse>> GetAllStatesAsync()
    {
        var states = await _repo.GetAllAsync();

        return states.Select(s => new StateResponse
        {
            StateCode = s.StateCode,
            StateName = s.StateName,
            Country = s.Country,
            IsActive = s.IsActive
        }).ToList();
    }

    public async Task<StateResponse?> GetStateByCodeAsync(string stateCode)
    {
        var s = await _repo.GetByCodeAsync(stateCode);
        if (s == null) return null;

        return new StateResponse
        {
            StateCode = s.StateCode,
            StateName = s.StateName,
            Country = s.Country,
            IsActive = s.IsActive
        };
    }
}
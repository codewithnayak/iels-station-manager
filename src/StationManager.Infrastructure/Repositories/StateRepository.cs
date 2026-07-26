using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StationManager.Infrastructure.Repositories;

public class StateRepository : IStateRepository
{
    private readonly StationDbContext _db;

    public StateRepository(StationDbContext db)
    {
        _db = db;
    }

    public async Task<State> AddAsync(State state)
    {
        _db.States.Add(state);
        await _db.SaveChangesAsync();
        return state;
    }

    public async Task<State?> GetByCodeAsync(string stateCode)
    {
        return await _db.States.FirstOrDefaultAsync(x => x.StateCode == stateCode);
    }

    public async Task<List<State>> GetAllAsync()
    {
        return await _db.States.Where(x => x.IsActive).ToListAsync();
    }
}
public interface IStateService
{
    Task<StateResponse> CreateStateAsync(CreateStateRequest request);
    Task<List<StateResponse>> GetAllStatesAsync();
    Task<StateResponse?> GetStateByCodeAsync(string stateCode);
}
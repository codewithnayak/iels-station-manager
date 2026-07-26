public interface IStationService
{
    Task<StationResponse> CreateStationAsync(CreateStationRequest request);
    Task<List<StationResponse>> GetAllStationsAsync();
    Task<StationResponse?> GetStationByIdAsync(string stationId);
}
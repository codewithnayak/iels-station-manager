public interface IStationSequenceService
{
    Task<long> GetNextSequenceAsync(string stationId);
}
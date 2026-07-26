namespace CaseManager.Domain.Entities;

public class StationSequence
{
    public string StationId { get; set; }
    public int Year { get; set; }
    public long CurrentValue { get; set; }
}
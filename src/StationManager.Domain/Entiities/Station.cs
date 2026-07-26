namespace CaseManager.Domain.Entities;

public class Station
{
    public string StationId { get; set; }          // PS101
    public string StationCode { get; set; }        // PS101
    public string StationName { get; set; }        // Bhubaneswar Town PS
    public string StateCode { get; set; }          // OD
    public string District { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
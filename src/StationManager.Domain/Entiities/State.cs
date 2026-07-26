namespace CaseManager.Domain.Entities;

public class State
{
    public string StateCode { get; set; }      // OD, MH, RJ
    public string StateName { get; set; }      // Odisha, Maharashtra
    public string Country { get; set; }        // India
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
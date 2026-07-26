using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class StationDbContext : DbContext
{
    public StationDbContext(DbContextOptions<StationDbContext> options) : base(options) {}

    public DbSet<State> States { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<StationSequence> StationSequences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StationDbContext).Assembly);
    }
}
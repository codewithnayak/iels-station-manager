using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StationSequenceConfiguration : IEntityTypeConfiguration<StationSequence>
{
    public void Configure(EntityTypeBuilder<StationSequence> builder)
    {
        builder.HasKey(x => new { x.StationId, x.Year });

        builder.Property(x => x.CurrentValue).IsRequired();
    }
}
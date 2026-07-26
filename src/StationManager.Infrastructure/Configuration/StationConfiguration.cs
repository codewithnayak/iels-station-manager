using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.HasKey(x => x.StationId);

        builder.Property(x => x.StationCode).IsRequired().HasMaxLength(20);
        builder.Property(x => x.StationName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.StateCode).IsRequired().HasMaxLength(10);
        builder.Property(x => x.District).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(300);

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW()");
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("NOW()");
    }
}
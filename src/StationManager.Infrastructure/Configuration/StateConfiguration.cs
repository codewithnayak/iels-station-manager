using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.StateCode);

        builder.Property(x => x.StateName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(100);

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW()");
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("NOW()");
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Name).HasColumnName("Name");
        builder.Property(r => r.ParentId).HasColumnName("ParentId");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);

        Region[] regionSeeds =
        [
                new() {Id = Guid.NewGuid(), Name = "Istanbul-Avrupa" },
                new() {Id = Guid.NewGuid(), Name = "Istanbul-Anadolu" },
                new() {Id = Guid.NewGuid(), Name = "Ankara" }
        ];
        builder.HasData(regionSeeds);
    }
}
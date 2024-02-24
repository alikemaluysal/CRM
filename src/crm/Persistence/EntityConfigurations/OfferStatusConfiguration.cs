using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OfferStatusConfiguration : IEntityTypeConfiguration<OfferStatus>
{
    public void Configure(EntityTypeBuilder<OfferStatus> builder)
    {
        builder.ToTable("OfferStatus").HasKey(os => os.Id);

        builder.Property(os => os.Id).HasColumnName("Id").IsRequired();
        builder.Property(os => os.Name).HasColumnName("Name");
        builder.Property(os => os.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(os => os.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(os => os.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(os => !os.DeletedDate.HasValue);

        OfferStatus[] offerStatusSeeds =
        [
                new() {Id = Guid.NewGuid(), Name = "Open" },
                new() {Id = Guid.NewGuid(), Name = "In Progress" },
                new() {Id = Guid.NewGuid(), Name = "Resolved" },
                new() {Id = Guid.NewGuid(), Name = "Closed" }
        ];
        builder.HasData(offerStatusSeeds);

    }
}
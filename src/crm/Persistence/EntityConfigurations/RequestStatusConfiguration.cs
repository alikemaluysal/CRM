using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
{
    public void Configure(EntityTypeBuilder<RequestStatus> builder)
    {
        builder.ToTable("RequestStatus").HasKey(rs => rs.Id);

        builder.Property(rs => rs.Id).HasColumnName("Id").IsRequired();
        builder.Property(rs => rs.Name).HasColumnName("Name");
        builder.Property(rs => rs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rs => rs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rs => rs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rs => !rs.DeletedDate.HasValue);

        RequestStatus[] requestStatusSeeds =
        [
                new() {Id = Guid.NewGuid(), Name = "Open" },
                new() {Id = Guid.NewGuid(), Name = "In Progress" },
                new() {Id = Guid.NewGuid(), Name = "Resolved" },
                new() {Id = Guid.NewGuid(), Name = "Closed" }
        ];

        builder.HasData(requestStatusSeeds);
    }
}
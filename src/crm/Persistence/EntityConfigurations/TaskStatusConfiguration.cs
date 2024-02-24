using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Persistence.EntityConfigurations;

public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
{
    public void Configure(EntityTypeBuilder<TaskStatus> builder)
    {
        builder.ToTable("TaskStatus").HasKey(ts => ts.Id);

        builder.Property(ts => ts.Id).HasColumnName("Id").IsRequired();
        builder.Property(ts => ts.Name).HasColumnName("Name");
        builder.Property(ts => ts.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ts => ts.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ts => ts.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ts => !ts.DeletedDate.HasValue);

        TaskStatus[] taskStatusSeeds =
        [
                new() {Id = Guid.NewGuid(), Name = "Open" },
                new() {Id = Guid.NewGuid(), Name = "In Progress" },
                new() {Id = Guid.NewGuid(), Name = "Resolved" },
                new() {Id = Guid.NewGuid(), Name = "Closed" }
        ];

        builder.HasData(taskStatusSeeds);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("TaskEntities").HasKey(te => te.Id);

        builder.Property(te => te.Id).HasColumnName("Id").IsRequired();
        builder.Property(te => te.RequestId).HasColumnName("RequestId");
        builder.Property(te => te.EmployeeUserId).HasColumnName("EmployeeUserId");
        builder.Property(te => te.TaskStartDate).HasColumnName("TaskStartDate");
        builder.Property(te => te.TaskEndDate).HasColumnName("TaskEndDate");
        builder.Property(te => te.Description).HasColumnName("Description");
        builder.Property(te => te.TaskStatusId).HasColumnName("TaskStatusId");
        builder.Property(te => te.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(te => te.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(te => te.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(te => !te.DeletedDate.HasValue);
    }
}
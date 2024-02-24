using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.UserId).HasColumnName("UserId");
        builder.Property(e => e.IdentityNumber).HasColumnName("IdentityNumber");
        builder.Property(e => e.GenderId).HasColumnName("GenderId");
        builder.Property(e => e.TitleId).HasColumnName("TitleId");
        builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId");
        builder.Property(e => e.StartDate).HasColumnName("StartDate");
        builder.Property(e => e.StatusTypeId).HasColumnName("StatusTypeId");
        builder.Property(e => e.RegionId).HasColumnName("RegionId");
        builder.Property(e => e.BirthDate).HasColumnName("BirthDate");
        builder.Property(e => e.ParentEmployeeId).HasColumnName("ParentEmployeeId");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.IdentityNumber).HasColumnName("IdentityNumber");
        builder.Property(c => c.GenderId).HasColumnName("GenderId");
        builder.Property(c => c.TitleId).HasColumnName("TitleId");
        builder.Property(c => c.CompanyName).HasColumnName("CompanyName");
        builder.Property(c => c.StatusTypeId).HasColumnName("StatusTypeId");
        builder.Property(c => c.CustomerType).HasColumnName("CustomerType");
        builder.Property(c => c.RegionId).HasColumnName("RegionId");
        builder.Property(c => c.BirthDate).HasColumnName("BirthDate");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
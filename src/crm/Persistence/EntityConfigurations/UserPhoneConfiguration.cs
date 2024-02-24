using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserPhoneConfiguration : IEntityTypeConfiguration<UserPhone>
{
    public void Configure(EntityTypeBuilder<UserPhone> builder)
    {
        builder.ToTable("UserPhones").HasKey(up => up.Id);

        builder.Property(up => up.Id).HasColumnName("Id").IsRequired();
        builder.Property(up => up.UserId).HasColumnName("UserId");
        builder.Property(up => up.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(up => up.PhoneType).HasColumnName("PhoneType");
        builder.Property(up => up.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(up => up.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(up => up.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(up => !up.DeletedDate.HasValue);
    }
}
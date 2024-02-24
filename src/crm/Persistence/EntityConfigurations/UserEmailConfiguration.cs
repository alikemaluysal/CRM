using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserEmailConfiguration : IEntityTypeConfiguration<UserEmail>
{
    public void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        builder.ToTable("UserEmails").HasKey(ue => ue.Id);

        builder.Property(ue => ue.Id).HasColumnName("Id").IsRequired();
        builder.Property(ue => ue.UserId).HasColumnName("UserId");
        builder.Property(ue => ue.EmailAddress).HasColumnName("EmailAddress");
        builder.Property(ue => ue.EmailType).HasColumnName("EmailType");
        builder.Property(ue => ue.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ue => ue.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ue => ue.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ue => !ue.DeletedDate.HasValue);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.RequestId).HasColumnName("RequestId");
        builder.Property(o => o.EmployeeUserId).HasColumnName("EmployeeUserId");
        builder.Property(o => o.OfferDate).HasColumnName("OfferDate");
        builder.Property(o => o.BidAmount).HasColumnName("BidAmount");
        builder.Property(o => o.OfferStatusId).HasColumnName("OfferStatusId");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}
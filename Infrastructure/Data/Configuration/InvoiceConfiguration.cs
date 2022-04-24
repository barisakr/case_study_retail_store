using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.InvoiceNumber).IsRequired();
            builder.Property(x => x.TotalQuantity).IsRequired();
            builder.Property(x => x.TotalNetAmount).HasColumnType("decimal(19,2)").IsRequired();

            builder.Property(x => x.TotalAmount).HasColumnType("decimal(19,2)")
            .IsRequired();
            builder.Property(x => x.TotalDiscountAmount).HasColumnType("decimal(19,2)");

            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.InvoiceDetails).WithOne().HasForeignKey(x => x.InvoiceId);

        }
    }
}
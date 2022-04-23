using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.InvoiceId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired(); 
            builder.Property(x => x.Amount).HasColumnType("decimal(19,2)").IsRequired();
            builder.Property(x => x.DiscountAmount).HasColumnType("decimal(19,2)").IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Invoice).WithMany().HasForeignKey(x => x.InvoiceId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
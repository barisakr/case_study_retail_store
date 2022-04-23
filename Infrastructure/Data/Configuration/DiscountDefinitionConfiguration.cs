using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DiscountDefinitionConfiguration : IEntityTypeConfiguration<DiscountDefinition>
    {
        public void Configure(EntityTypeBuilder<DiscountDefinition> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DiscountType).IsRequired();
            builder.Property(x => x.Ratio).HasColumnType("decimal(19,2)");
            builder.Property(x => x.IsRatio).IsRequired();
            
        }
    }
}
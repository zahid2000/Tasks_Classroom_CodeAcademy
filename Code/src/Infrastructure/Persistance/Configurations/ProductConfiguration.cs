using Code.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Code.Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.UnitPrice).IsRequired(true);
            builder.Property(x => x.UnitsInStock).IsRequired(true);
            builder.Property(x => x.CategoryId).IsRequired(false);
            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryId);

        }
    }
}

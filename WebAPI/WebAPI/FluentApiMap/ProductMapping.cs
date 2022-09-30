

namespace WebAPI.FluentApiMap
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.Property(p => p.ProductName).HasMaxLength(40).IsRequired(true).HasColumnType("nvarchar");
            builder.Property(p => p.QuantityPerUnit).HasMaxLength(20).IsRequired(false).HasColumnType("nvarchar");
            builder.Property(p => p.UnitPrice).IsRequired(false).HasColumnType("money");
            builder.Property(p => p.UnitsInStock).IsRequired(false).HasColumnType("smallint");
            builder.Property(p => p.UnitsOnOrder).IsRequired(false).HasColumnType("smallint");
            builder.Property(p => p.ReorderLevel).IsRequired(false).HasColumnType("smallint");
            builder.Property(p => p.Discontinued).IsRequired(true).HasColumnType("bit");
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID);
        }
    }
}

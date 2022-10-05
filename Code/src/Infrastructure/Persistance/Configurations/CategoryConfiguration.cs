namespace Code.Infrastructure.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.CategoryName).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
    }
}

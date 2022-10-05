namespace Infastructure.Persistance;

public class ApplicationDbContext:ApiAuthorizationDbContext<ApplicationUser>,IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IOptions<OperationalStoreOptions> operationalStoreOptions):base(options, operationalStoreOptions)
    {

    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}

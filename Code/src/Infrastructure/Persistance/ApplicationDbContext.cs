using Code.Infrastructure.Persistance.Interceptors;

namespace Infastructure.Persistance;

public class ApplicationDbContext:ApiAuthorizationDbContext<ApplicationUser>,IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptors _auditableEntitySaveChangesInterceptors;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions, AuditableEntitySaveChangesInterceptors auditableEntitySaveChangesInterceptors) : base(options, operationalStoreOptions)
    {
        _auditableEntitySaveChangesInterceptors = auditableEntitySaveChangesInterceptors;
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptors);
        base.OnConfiguring(optionsBuilder);
    }
}

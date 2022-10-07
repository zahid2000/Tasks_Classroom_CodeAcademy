using Code.Infrastructure.Persistance;
using Code.Infrastructure.Persistance.Interceptors;
using Code.Infrastructure.Service;

namespace Code.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddInfastructureServices(this IServiceCollection serviceCollection,IConfiguration configuration)
    {

        serviceCollection.AddScoped<AuditableEntitySaveChangesInterceptors>();

        serviceCollection.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        builderOptions=>
        builderOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        serviceCollection.AddScoped<ApplicationDbContextInitialiser>();

        serviceCollection
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

         serviceCollection
            .AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();


        serviceCollection.AddTransient<IDateTime, DateTimeService>();


        serviceCollection.AddTransient<IIdentityService, IdentityService>();

        serviceCollection.AddAuthentication().AddIdentityServerJwt();
        return serviceCollection;
    }
}

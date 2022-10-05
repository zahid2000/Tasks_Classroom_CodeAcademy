using Microsoft.Extensions.Logging;

namespace Code.Infrastructure.Persistance
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;

        public ApplicationDbContextInitialiser(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<ApplicationDbContextInitialiser> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {

                _logger.LogError("An error occured while inialising the database ....");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception)
            {

                _logger.LogError("An error occured while seeding the database ....");
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
            //Default Roles
            var adminstratorRole = new IdentityRole("administrator");
            if (_roleManager.Roles.All(r => r.Name != adminstratorRole.Name))
            {
                await _roleManager.CreateAsync(adminstratorRole);
            }
            //Default Users
            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost.com" };
            if (_userManager.Users.All(u => u.UserName != administrator.UserName)){
                await _userManager.CreateAsync(administrator,"ad$$min1");
                //await  _userManager.AddToRoleAsync(administrator,adminstratorRole.Name)  //bir rol varsa
                await _userManager.AddToRolesAsync(administrator, new[] { adminstratorRole.Name });  //cox rol varsa
            }

            //Default Categories
            if (!_context.Categories.Any())
            {
                await _context.Categories.AddRangeAsync(
                    new Category { CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
                    new Category { CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                    new Category { CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                    new Category { CategoryName = "Dairy Products", Description = "Cheeses" },
                    new Category { CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
                    new Category { CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                    new Category { CategoryName = "Produce", Description = "Dried fruit and bean curd" },
                    new Category { CategoryName = "Seafood", Description = "Seaweed and fish" }
                    );
            }
            await _context.SaveChangesAsync();
        }
    }
}

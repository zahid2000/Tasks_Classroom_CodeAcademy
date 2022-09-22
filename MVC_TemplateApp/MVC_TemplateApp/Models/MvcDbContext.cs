using Microsoft.EntityFrameworkCore;

namespace MVC_TemplateApp.Models
{
    public class MvcDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=MvcDb;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
    }
}

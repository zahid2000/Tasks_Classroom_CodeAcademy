
using SignalRApp.Models;

namespace SignalRApp.Data
{
    public class AppDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=SignalRAppDb;Trusted_Connection=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public virtual DbSet<Product> Products{ get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Login_Register_App.Models
{
    public class LoginRegisterDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-QBQM5QA\SQLEXPRESS;database=LoginRegisteDB;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}

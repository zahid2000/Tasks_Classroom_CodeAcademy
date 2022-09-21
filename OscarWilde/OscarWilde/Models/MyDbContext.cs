using Microsoft.EntityFrameworkCore;
using OscarWilde.Models;

namespace OscarWilde.Model
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=OscarWildeDb;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Computer> Computers { get; set; }
    }
}

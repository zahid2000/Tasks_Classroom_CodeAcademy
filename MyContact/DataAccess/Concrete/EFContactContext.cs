using MyContact.Models;
using Microsoft.EntityFrameworkCore;

namespace MyContact.DataAccess.Concrete
{
    public class EFContactContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-QBQM5QA\SQLEXPRESS;database=MyContactDb;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Contact> Contacts { get; set; }
       
    }
}
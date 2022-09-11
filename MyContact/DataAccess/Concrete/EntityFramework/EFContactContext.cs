using MyContact.Models;
using Microsoft.EntityFrameworkCore;
using MyContact.Core.Constants;

namespace MyContact.DataAccess.Concrete.EntityFramework
{
    public class EFContactContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.EFConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Contact> Contacts { get; set; }

    }
}
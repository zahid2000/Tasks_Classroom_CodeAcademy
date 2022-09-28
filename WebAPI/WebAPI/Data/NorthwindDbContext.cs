using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class NorthwindDbContext:DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options):base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
    }
}

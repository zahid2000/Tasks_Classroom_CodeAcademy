using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_TemplateApp.Models
{
    public class MvcDbContext:IdentityDbContext<IdentityUser>
    {
      public MvcDbContext (DbContextOptions opt):base(opt){}  
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
    }
}

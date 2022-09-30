
using System.Reflection;
using WebAPI.FluentApiMap;

namespace WebAPI.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .HasMaxLength(25)
                .IsRequired(true);
            modelBuilder.Entity<Category>()
                .Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false)
                .HasColumnType("nvarchar");

            //modelBuilder.Entity<StudentCourses>()
            //    .HasKey(cs => new { cs.Student, cs.CourseId });
            //modelBuilder.Entity<StudentCourses>()
            //    .HasOne(c => c.Course)
            //    .WithMany(c => c.Students)
            //    .HasForeignKey(c => c.CourseId);
            //modelBuilder.Entity<StudentCourses>()
            //    .HasOne(c => c.Student)
            //    .WithMany(c => c.Courses)
            //    .HasForeignKey(c => c.Student);



            //modelBuilder.ApplyConfiguration(new CategoryMapping());
            //modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

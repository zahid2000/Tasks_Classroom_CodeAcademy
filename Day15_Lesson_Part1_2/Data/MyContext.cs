using Microsoft.EntityFrameworkCore;
using Day15_Lesson_Part1_2.Models;

namespace Day15_Lesson_Part1_2.Data;
public class MyContext : DbContext
{
    public virtual DbSet<Country> Countries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=CANR2-10\SQLEXPRESS;database=CodeFirstDb;trusted_connection=true");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(model =>
        {
            model.HasKey(prop => prop.Id);
            model.Property(prop => prop.Name).HasMaxLength(10).IsRequired(true);
            model.Property(prop => prop.ISO).HasMaxLength(200).IsRequired(false);
            model.Property(prop => prop.Code).HasMaxLength(2).IsRequired(false);
            model.Property(prop => prop.Phone).HasMaxLength(30).IsRequired(false);
            model.Property(prop => prop.Capital).HasMaxLength(100).IsRequired(false);
            model.Property(prop => prop.Currency).HasMaxLength(10).IsRequired(false);
            model.Property(prop => prop.Continent).HasMaxLength(200).IsRequired(false);
            model.Property(prop => prop.Property).HasMaxLength(200).IsRequired(false);
        });
        base.OnModelCreating(modelBuilder);
    }

     
}
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CV> CVs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CV>()
                .Property(x => x.Skills)
                .HasConversion(
                 v => string.Join(",", v),
                 v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                 );
        }

    }
}

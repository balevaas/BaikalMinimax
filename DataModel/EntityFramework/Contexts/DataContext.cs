using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModel.EntityFramework.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Point> Points { get; set; } = null!;
        public DbSet<Concentration> Concentrations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(u => new { u.Id });
            modelBuilder.Entity<Point>().HasKey(u => new { u.Id });
            modelBuilder.Entity<Concentration>().HasKey(u => new { u.Id });
        }
    }
}

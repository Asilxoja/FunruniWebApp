using FuniWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FuniWebApp.Data
{
    public class FuniWebDbContext : DbContext
    {
        public FuniWebDbContext(DbContextOptions<FuniWebDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Funi> Funis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Funis)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

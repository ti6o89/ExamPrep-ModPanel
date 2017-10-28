using Microsoft.EntityFrameworkCore;
using ModPanel.App.Data.Models;

namespace ModPanel.App.Data
{
    public class ModPanelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=ModPanelDatabase;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}

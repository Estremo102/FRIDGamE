using FRIDGamE.Models;
using Microsoft.EntityFrameworkCore;

namespace FRIDGamE.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "games.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = D:\\data\\fridgame\\fridge.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}

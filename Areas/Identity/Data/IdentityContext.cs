using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FRIDGamE.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<FRIDGamEUser>
{

    public DbSet<Game> Games { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<FRIDGamEUser> Users { get; set; }
    public DbSet<News> News { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<FRIDGamEUser>()
            .HasMany(e => e.News)
            .WithOne(e => e.Author);
        builder.Entity<FRIDGamEUser>()
            .HasMany(e => e.Games)
            .WithMany(e => e.Owners);

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<FRIDGamE.Models.Promotion> Promotion { get; set; }
}

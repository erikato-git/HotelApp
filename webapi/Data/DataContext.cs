using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

// To execute EF-commands in VS Code, RUN: dotnet tool install dotnet-ef -g
// Add-migrations: dotnet ef migrations add [name]
// Update database: dotnet ef database update

// Connect to Postgresql extension: 1. connection-string, 2. choose 'WebApi'

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // One-to-Many: Hotel 1 .. * Room
        builder.Entity<Room>()
            .HasOne(a => a.Hotel)
            .WithMany(c => c.Rooms)
            .OnDelete(DeleteBehavior.Cascade);

    }

}

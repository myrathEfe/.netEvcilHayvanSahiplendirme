using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<AppUser> Users => Set<AppUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>()
            .HasIndex(x => x.Username)
            .IsUnique();

        modelBuilder.Entity<Pet>()
            .Property(x => x.ImageData)
            .HasColumnType("varbinary(max)");
    }
}

using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Helpers;
using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        if (!await context.Users.AnyAsync())
        {
            context.Users.AddRange(
                new AppUser
                {
                    Username = "admin",
                    PasswordHash = PasswordHasher.Hash("admin123"),
                    Role = RoleNames.Admin,
                    CreatedDate = DateTime.UtcNow
                },
                new AppUser
                {
                    Username = "user",
                    PasswordHash = PasswordHasher.Hash("user123"),
                    Role = RoleNames.User,
                    CreatedDate = DateTime.UtcNow
                });

            await context.SaveChangesAsync();
        }

        var petsWithoutContactPhone = await context.Pets
            .Where(x => string.IsNullOrWhiteSpace(x.ContactPhone))
            .ToListAsync();

        if (petsWithoutContactPhone.Count > 0)
        {
            var demoPhones = new[] { "0532 123 45 67", "0543 234 56 78", "0555 345 67 89" };
            for (var i = 0; i < petsWithoutContactPhone.Count; i++)
            {
                petsWithoutContactPhone[i].ContactPhone = demoPhones[i % demoPhones.Length];
            }

            await context.SaveChangesAsync();
        }
    }
}

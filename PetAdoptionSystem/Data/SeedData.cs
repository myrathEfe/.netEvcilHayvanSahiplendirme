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

        var petsWithDifferentContactPhone = await context.Pets
            .Where(x => x.ContactPhone != ShelterInfo.PhoneDisplay)
            .ToListAsync();

        if (petsWithDifferentContactPhone.Count > 0)
        {
            foreach (var pet in petsWithDifferentContactPhone)
            {
                pet.ContactPhone = ShelterInfo.PhoneDisplay;
            }

            await context.SaveChangesAsync();
        }
    }
}

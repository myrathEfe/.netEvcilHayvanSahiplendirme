using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Services;

public interface IAuthService
{
    Task<AppUser?> ValidateUserAsync(string username, string password);
}

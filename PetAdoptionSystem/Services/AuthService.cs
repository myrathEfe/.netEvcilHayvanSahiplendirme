using PetAdoptionSystem.DataAccess.Repositories;
using PetAdoptionSystem.Helpers;
using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AppUser?> ValidateUserAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        if (user is null)
        {
            return null;
        }

        var hashedPassword = PasswordHasher.Hash(password);
        return user.PasswordHash == hashedPassword ? user : null;
    }
}

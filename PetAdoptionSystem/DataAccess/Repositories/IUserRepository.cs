using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.DataAccess.Repositories;

public interface IUserRepository
{
    Task<AppUser?> GetByUsernameAsync(string username);
}

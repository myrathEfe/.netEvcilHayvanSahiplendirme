using PetAdoptionSystem.Models;
using PetAdoptionSystem.Models.Enums;
using PetAdoptionSystem.Services.Models;

namespace PetAdoptionSystem.DataAccess.Repositories;

public interface IPetRepository
{
    Task<List<Pet>> SearchAsync(PetSearchRequest request);
    Task<List<Pet>> GetRecentAsync(int count);
    Task<Pet?> GetByIdAsync(int id);
    Task AddAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(Pet pet);
    Task<int> CountAsync();
    Task<int> CountByStatusAsync(AdoptionStatus status);
}

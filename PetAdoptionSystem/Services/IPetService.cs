using PetAdoptionSystem.Models;
using PetAdoptionSystem.Services.Models;

namespace PetAdoptionSystem.Services;

public interface IPetService
{
    Task<List<Pet>> SearchAsync(PetSearchRequest request);
    Task<Pet?> GetByIdAsync(int id);
    Task CreateAsync(Pet pet);
    Task<bool> UpdateAsync(int id, Pet updatedPet, bool replaceImage);
    Task<bool> DeleteAsync(int id);
    Task<bool> MarkAsAdoptedAsync(int id);
    Task<DashboardSummary> GetDashboardAsync();
}

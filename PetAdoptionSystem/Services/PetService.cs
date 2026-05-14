using PetAdoptionSystem.DataAccess.Repositories;
using PetAdoptionSystem.Models;
using PetAdoptionSystem.Models.Enums;
using PetAdoptionSystem.Services.Models;

namespace PetAdoptionSystem.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<List<Pet>> SearchAsync(PetSearchRequest request)
    {
        return await _petRepository.SearchAsync(request);
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _petRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Pet pet)
    {
        pet.CreatedDate = DateTime.UtcNow;
        await _petRepository.AddAsync(pet);
    }

    public async Task<bool> UpdateAsync(int id, Pet updatedPet, bool replaceImage)
    {
        var existingPet = await _petRepository.GetByIdAsync(id);
        if (existingPet is null)
        {
            return false;
        }

        existingPet.Name = updatedPet.Name;
        existingPet.Species = updatedPet.Species;
        existingPet.Breed = updatedPet.Breed;
        existingPet.Age = updatedPet.Age;
        existingPet.Gender = updatedPet.Gender;
        existingPet.City = updatedPet.City;
        existingPet.Description = updatedPet.Description;
        existingPet.AdoptionStatus = updatedPet.AdoptionStatus;

        if (replaceImage)
        {
            existingPet.ImageData = updatedPet.ImageData;
            existingPet.ImageContentType = updatedPet.ImageContentType;
        }

        await _petRepository.UpdateAsync(existingPet);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pet = await _petRepository.GetByIdAsync(id);
        if (pet is null)
        {
            return false;
        }

        await _petRepository.DeleteAsync(pet);
        return true;
    }

    public async Task<DashboardSummary> GetDashboardAsync()
    {
        return new DashboardSummary
        {
            TotalPets = await _petRepository.CountAsync(),
            AvailablePets = await _petRepository.CountByStatusAsync(AdoptionStatus.Available),
            AdoptedPets = await _petRepository.CountByStatusAsync(AdoptionStatus.Adopted),
            RecentPets = await _petRepository.GetRecentAsync(5)
        };
    }
}

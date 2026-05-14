using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.ViewModels;

public class DashboardViewModel
{
    public int TotalPets { get; set; }
    public int AvailablePets { get; set; }
    public int AdoptedPets { get; set; }
    public List<Pet> RecentPets { get; set; } = new();
}

using Microsoft.AspNetCore.Mvc;
using PetAdoptionSystem.Filters;
using PetAdoptionSystem.Services;
using PetAdoptionSystem.ViewModels;

namespace PetAdoptionSystem.Controllers;

[SessionAuthorize]
public class DashboardController : Controller
{
    private readonly IPetService _petService;

    public DashboardController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var summary = await _petService.GetDashboardAsync();
        var model = new DashboardViewModel
        {
            TotalPets = summary.TotalPets,
            AvailablePets = summary.AvailablePets,
            AdoptedPets = summary.AdoptedPets,
            RecentPets = summary.RecentPets
        };

        return View(model);
    }
}

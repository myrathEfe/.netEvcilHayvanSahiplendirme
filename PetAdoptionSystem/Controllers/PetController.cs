using Microsoft.AspNetCore.Mvc;
using PetAdoptionSystem.Filters;
using PetAdoptionSystem.Helpers;
using PetAdoptionSystem.Models;
using PetAdoptionSystem.Services;
using PetAdoptionSystem.Services.Models;
using PetAdoptionSystem.ViewModels;

namespace PetAdoptionSystem.Controllers;

public class PetController : Controller
{
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] PetFilterViewModel filter)
    {
        if (filter.MinAge.HasValue && filter.MaxAge.HasValue && filter.MinAge > filter.MaxAge)
        {
            ModelState.AddModelError(string.Empty, "Minimum yaş, maksimum yaştan büyük olamaz.");
        }

        var request = new PetSearchRequest
        {
            Name = filter.Name,
            Species = filter.Species,
            Breed = filter.Breed,
            City = filter.City,
            MinAge = filter.MinAge,
            MaxAge = filter.MaxAge,
            AdoptionStatus = filter.AdoptionStatus
        };

        filter.Pets = await _petService.SearchAsync(request);
        return View(filter);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var pet = await _petService.GetByIdAsync(id);
        if (pet is null)
        {
            return NotFound();
        }

        return View(pet);
    }

    [HttpGet("/Pet/Image/{id:int}")]
    public async Task<IActionResult> Image(int id)
    {
        var pet = await _petService.GetByIdAsync(id);
        if (pet is null || pet.ImageData is null || string.IsNullOrWhiteSpace(pet.ImageContentType))
        {
            return NotFound();
        }

        return File(pet.ImageData, pet.ImageContentType);
    }

    [HttpGet]
    [SessionAuthorize(RoleNames.Admin)]
    public IActionResult Create()
    {
        return View(new PetFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [SessionAuthorize(RoleNames.Admin)]
    public async Task<IActionResult> Create(PetFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var imageBytes = await ReadImageBytesAsync(model.ImageFile);
        var pet = new Pet
        {
            Name = model.Name.Trim(),
            Species = model.Species!.Value,
            Breed = model.Breed.Trim(),
            Age = model.Age,
            Gender = model.Gender!.Value,
            City = model.City.Trim(),
            ContactPhone = model.ContactPhone.Trim(),
            Description = model.Description?.Trim(),
            AdoptionStatus = model.AdoptionStatus!.Value,
            ImageData = imageBytes,
            ImageContentType = model.ImageFile?.ContentType
        };

        await _petService.CreateAsync(pet);
        TempData["StatusMessage"] = "İlan başarıyla eklendi.";
        TempData["StatusType"] = "success";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [SessionAuthorize(RoleNames.Admin)]
    public async Task<IActionResult> Edit(int id)
    {
        var pet = await _petService.GetByIdAsync(id);
        if (pet is null)
        {
            return NotFound();
        }

        var model = new PetFormViewModel
        {
            Id = pet.Id,
            Name = pet.Name,
            Species = pet.Species,
            Breed = pet.Breed,
            Age = pet.Age,
            Gender = pet.Gender,
            City = pet.City,
            ContactPhone = pet.ContactPhone,
            Description = pet.Description,
            AdoptionStatus = pet.AdoptionStatus,
            HasExistingImage = pet.ImageData is not null
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [SessionAuthorize(RoleNames.Admin)]
    public async Task<IActionResult> Edit(int id, PetFormViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var imageBytes = await ReadImageBytesAsync(model.ImageFile);
        var updatedPet = new Pet
        {
            Id = model.Id,
            Name = model.Name.Trim(),
            Species = model.Species!.Value,
            Breed = model.Breed.Trim(),
            Age = model.Age,
            Gender = model.Gender!.Value,
            City = model.City.Trim(),
            ContactPhone = model.ContactPhone.Trim(),
            Description = model.Description?.Trim(),
            AdoptionStatus = model.AdoptionStatus!.Value,
            ImageData = imageBytes,
            ImageContentType = model.ImageFile?.ContentType
        };

        var updated = await _petService.UpdateAsync(id, updatedPet, model.ImageFile is not null);
        if (!updated)
        {
            return NotFound();
        }

        TempData["StatusMessage"] = "İlan başarıyla güncellendi.";
        TempData["StatusType"] = "success";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [SessionAuthorize(RoleNames.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _petService.GetByIdAsync(id);
        if (pet is null)
        {
            return NotFound();
        }

        return View(pet);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [SessionAuthorize(RoleNames.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _petService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        TempData["StatusMessage"] = "İlan başarıyla silindi.";
        TempData["StatusType"] = "warning";
        return RedirectToAction(nameof(Index));
    }

    private static async Task<byte[]?> ReadImageBytesAsync(IFormFile? imageFile)
    {
        if (imageFile is null || imageFile.Length == 0)
        {
            return null;
        }

        using var memoryStream = new MemoryStream();
        await imageFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}

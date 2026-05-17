using PetAdoptionSystem.Models.Enums;

namespace PetAdoptionSystem.Services.Models;

public class PetSearchRequest
{
    public string? Name { get; set; }
    public SpeciesType? Species { get; set; }
    public string? Breed { get; set; }
    public string? City { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public AdoptionStatus? AdoptionStatus { get; set; }
    public DisabilityStatus? DisabilityStatus { get; set; }
    public bool OnlyDisabled { get; set; }
}

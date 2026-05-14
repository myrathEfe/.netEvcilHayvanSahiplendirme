using System.ComponentModel.DataAnnotations;

namespace PetAdoptionSystem.Models.Enums;

public enum SpeciesType
{
    [Display(Name = "Kedi")]
    Cat = 1,

    [Display(Name = "Köpek")]
    Dog = 2,

    [Display(Name = "Kuş")]
    Bird = 3,

    [Display(Name = "Diğer")]
    Other = 4
}

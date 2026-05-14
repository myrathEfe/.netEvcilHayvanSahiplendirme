using System.ComponentModel.DataAnnotations;

namespace PetAdoptionSystem.Models.Enums;

public enum GenderType
{
    [Display(Name = "Dişi")]
    Female = 1,

    [Display(Name = "Erkek")]
    Male = 2
}

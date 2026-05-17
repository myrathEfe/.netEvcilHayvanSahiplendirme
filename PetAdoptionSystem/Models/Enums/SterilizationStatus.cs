using System.ComponentModel.DataAnnotations;

namespace PetAdoptionSystem.Models.Enums;

public enum SterilizationStatus
{
    [Display(Name = "Kısır")]
    Sterilized = 1,

    [Display(Name = "Kısır Değil")]
    NotSterilized = 2,

    [Display(Name = "Bilinmiyor")]
    Unknown = 3
}

using System.ComponentModel.DataAnnotations;

namespace PetAdoptionSystem.Models.Enums;

public enum DisabilityStatus
{
    [Display(Name = "Evet")]
    Yes = 1,

    [Display(Name = "Hayır")]
    No = 2,

    [Display(Name = "Bilinmiyor")]
    Unknown = 3
}

using System.ComponentModel.DataAnnotations;

namespace PetAdoptionSystem.Models.Enums;

public enum AdoptionStatus
{
    [Display(Name = "Sahiplendirilebilir")]
    Available = 1,

    [Display(Name = "Sahiplendirildi")]
    Adopted = 2
}

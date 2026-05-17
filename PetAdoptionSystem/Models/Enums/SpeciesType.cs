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
    Other = 4,

    [Display(Name = "Tavşan")]
    Rabbit = 5,

    [Display(Name = "Hamster")]
    Hamster = 6,

    [Display(Name = "Kobay")]
    GuineaPig = 7,

    [Display(Name = "Balık")]
    Fish = 8,

    [Display(Name = "Kaplumbağa")]
    Turtle = 9
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PetAdoptionSystem.Models.Enums;

namespace PetAdoptionSystem.ViewModels;

public class PetFormViewModel : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Hayvan adı zorunludur.")]
    [Display(Name = "Adı")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tür bilgisi zorunludur.")]
    [Display(Name = "Tür")]
    public SpeciesType? Species { get; set; }

    [Required(ErrorMessage = "Cins bilgisi zorunludur.")]
    [Display(Name = "Cins")]
    [StringLength(100)]
    public string Breed { get; set; } = string.Empty;

    [Range(0, 99, ErrorMessage = "Yaş negatif olamaz.")]
    [Display(Name = "Yaş")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Cinsiyet zorunludur.")]
    [Display(Name = "Cinsiyet")]
    public GenderType? Gender { get; set; }

    [Required(ErrorMessage = "Şehir bilgisi zorunludur.")]
    [Display(Name = "Şehir")]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Display(Name = "Açıklama")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Sahiplendirme durumu zorunludur.")]
    [Display(Name = "Sahiplendirme Durumu")]
    public AdoptionStatus? AdoptionStatus { get; set; }

    [Display(Name = "Fotoğraf")]
    public IFormFile? ImageFile { get; set; }

    public bool HasExistingImage { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ImageFile is not null)
        {
            var allowedTypes = new[] { "image/jpeg", "image/png" };
            if (!allowedTypes.Contains(ImageFile.ContentType))
            {
                yield return new ValidationResult(
                    "Yalnızca JPEG veya PNG formatında görsel yükleyebilirsiniz.",
                    new[] { nameof(ImageFile) });
            }
        }
    }
}

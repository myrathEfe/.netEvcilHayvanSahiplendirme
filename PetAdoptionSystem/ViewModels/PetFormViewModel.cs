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

    [Required(ErrorMessage = "İletişim numarası zorunludur.")]
    [Display(Name = "İletişim Numarası")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "İletişim numarası 10-20 karakter arasında olmalıdır.")]
    [RegularExpression(@"^[0-9+\s()-]{10,20}$", ErrorMessage = "Lütfen geçerli bir telefon numarası girin. Örn: 05xx xxx xx xx")]
    public string ContactPhone { get; set; } = string.Empty;

    [Display(Name = "Açıklama")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    public AdoptionStatus? AdoptionStatus { get; set; }

    [Display(Name = "Kısırlık Durumu")]
    public SterilizationStatus? SterilizationStatus { get; set; }

    [Required(ErrorMessage = "Engellilik durumu zorunludur.")]
    [Display(Name = "Engellilik durumu var mı?")]
    public DisabilityStatus? DisabilityStatus { get; set; } = PetAdoptionSystem.Models.Enums.DisabilityStatus.Unknown;

    [Display(Name = "Engel Nedir?")]
    [StringLength(500, ErrorMessage = "Engellilik açıklaması en fazla 500 karakter olabilir.")]
    public string? DisabilityDescription { get; set; }

    [Display(Name = "Fotoğraf")]
    public IFormFile? ImageFile { get; set; }

    public bool HasExistingImage { get; set; }

    public static bool SupportsSterilization(SpeciesType? species)
    {
        return species is SpeciesType.Cat
            or SpeciesType.Dog
            or SpeciesType.Rabbit
            or SpeciesType.Hamster
            or SpeciesType.GuineaPig;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SupportsSterilization(Species) && !SterilizationStatus.HasValue)
        {
            yield return new ValidationResult(
                "Bu tür için kısırlık durumu seçiniz.",
                new[] { nameof(SterilizationStatus) });
        }

        if (!SupportsSterilization(Species) && SterilizationStatus.HasValue)
        {
            yield return new ValidationResult(
                "Seçilen tür için kısırlık durumu kaydedilemez.",
                new[] { nameof(SterilizationStatus) });
        }

        if (DisabilityStatus == PetAdoptionSystem.Models.Enums.DisabilityStatus.Yes
            && string.IsNullOrWhiteSpace(DisabilityDescription))
        {
            yield return new ValidationResult(
                "Engellilik durumu Evet seçildiyse engelin ne olduğunu yazınız.",
                new[] { nameof(DisabilityDescription) });
        }

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

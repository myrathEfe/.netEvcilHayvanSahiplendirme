using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetAdoptionSystem.Models.Enums;

namespace PetAdoptionSystem.Models;

public class Pet
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Hayvan adı zorunludur.")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tür bilgisi zorunludur.")]
    public SpeciesType Species { get; set; }

    [Required(ErrorMessage = "Cins bilgisi zorunludur.")]
    [StringLength(100)]
    public string Breed { get; set; } = string.Empty;

    [Range(0, 99, ErrorMessage = "Yaş negatif olamaz.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Cinsiyet zorunludur.")]
    public GenderType Gender { get; set; }

    [Required(ErrorMessage = "Şehir bilgisi zorunludur.")]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "İletişim numarası zorunludur.")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "İletişim numarası 10-20 karakter arasında olmalıdır.")]
    [RegularExpression(@"^[0-9+\s()-]{10,20}$", ErrorMessage = "Lütfen geçerli bir telefon numarası girin. Örn: 05xx xxx xx xx")]
    public string ContactPhone { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Sahiplendirme durumu zorunludur.")]
    public AdoptionStatus AdoptionStatus { get; set; }

    [Column(TypeName = "varbinary(max)")]
    public byte[]? ImageData { get; set; }

    [StringLength(50)]
    public string? ImageContentType { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}

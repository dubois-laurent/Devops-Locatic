using System.ComponentModel.DataAnnotations;

namespace aspnet.Models.ViewModels
{
    public class CarModelCreateVM
    {
        [Required(ErrorMessage = "Le nom du modèle est obligatoire.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire.")]
        public CarBrand CarBrandId { get; set; }

        [Required(ErrorMessage = "Le prix journalier est obligatoire.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix journalier doit être supérieur ou égal à 0.")]
        public decimal DailyPrice { get; set; }
    }
}
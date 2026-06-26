using System.ComponentModel.DataAnnotations;

namespace aspnet.Models.ViewModels
{
    public class CarCreateVM
    {
        [Required(ErrorMessage = "Le modèle est obligatoire.")]
        public CarModel Model { get; set; }

        [Range(1, 15, ErrorMessage = "Chiffre entre 1 et 15.")]
        public int NbSeats { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace aspnet.Models.ViewModels
{
    public class CarReservationCreateVM
    {
        [Required(ErrorMessage = "La data de réservation est obligatoire.")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "La voiture est obligatoire.")]
        public int CarBrandId { get; set; }
    }
}
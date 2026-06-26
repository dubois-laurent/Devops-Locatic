using System.ComponentModel.DataAnnotations;

namespace aspnet.Models.ViewModels
{
    public class CarCustomerCreateVM
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public CarCustomer Name { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public CarCustomer Email { get; set; }

        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public CarCustomer PhoneNumber { get; set; }
    }
}
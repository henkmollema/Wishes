using System.ComponentModel.DataAnnotations;

namespace Wishes.Web.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        [MaxLength(50)]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password {get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [MaxLength(50)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres is verplicht")]
        [MaxLength(50)]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht")]
        [MaxLength(6)]
        [Display(Name = "Postcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Woonplaats is verplicht")]
        [MaxLength(50)]
        [Display(Name = "Woonplaats")]
        public string City { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Wishes.Web.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vul je gebruikersnaam in")]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vul je wachtwoord in")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

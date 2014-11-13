using System.ComponentModel.DataAnnotations;

namespace Wishes.Web.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Zipcode { get; set; }

        [Required]
        public string City { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Wishes.Web.Models.Account
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(6)]
        public string Zipcode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
    }
}

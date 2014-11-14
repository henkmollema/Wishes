using System.ComponentModel.DataAnnotations;

namespace Wishes.Core.Domain.Model
{
    public enum ChimneySize
    {
        [Display(Name = "Klein")]
        Small = 1,

        [Display(Name = "Middel")]
        Medium = 2,

        [Display(Name = "Groot")]
        Large = 3
    }
}

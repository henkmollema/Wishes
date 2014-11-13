using System.ComponentModel.DataAnnotations;

namespace Wishes.Web.Models.WishList
{
    public class WishListItemModel
    {
        [Required]
        public string ProductName { get; set; }
    }
}

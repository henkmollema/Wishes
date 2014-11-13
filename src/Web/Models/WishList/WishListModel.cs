using System.Collections.Generic;
using Wishes.Core.Domain.Model;

namespace Wishes.Web.Models.WishList
{
    public class WishListModel
    {
        public User User { get; set; }

        public WishListItemModel Item { get; set; }

        public IEnumerable<WishListItem> Items { get; set; }
    }
}

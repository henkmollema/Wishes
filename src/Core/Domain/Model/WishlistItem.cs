namespace Wishes.Core.Domain.Model
{
    public class WishListItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ProductName { get; set; }

        public int SortOrder { get; set; }

        public User User { get; set; }
    }
}

namespace Wishes.Core.Domain.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public ChimneySize ChimneySize { get; set; }
    }
}

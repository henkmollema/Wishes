using Dommel;
using Wishes.Core.Domain.Model;

namespace Wishes.Core.Data.Repositories
{
    public class UserRepository
    {
        public void Insert(User user)
        {
            using (var con = Database.GetOpenConnection())
            {
                con.Insert(user);
            }
        }
    }
}

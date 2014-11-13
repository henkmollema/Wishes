using System.Linq;
using Dapper;
using Dommel;
using Wishes.Core.Domain.Model;

namespace Wishes.Core.Data.Repositories
{
    public class UserRepository
    {
        public User Get(string username)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Query<User>("select * from Users where Username = @Username", new { Username = username }).FirstOrDefault();
            }
        }

        public int Insert(User user)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Insert(user);
            }
        }
    }
}

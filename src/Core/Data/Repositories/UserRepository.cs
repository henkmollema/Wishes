using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using Wishes.Core.Domain.Model;

namespace Wishes.Core.Data.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.GetAll<User>();
            }
        }

        public User Get(int id)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Get<User>(id);
            }
        }

        public User GetByName(string username)
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

        public void Update(User user)
        {
            using (var con = Database.GetOpenConnection())
            {
                con.Update(user);
            }
        }
    }
}

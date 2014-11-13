using System.Collections.Generic;
using Dapper;
using Dommel;
using Wishes.Core.Domain.Model;

namespace Wishes.Core.Data.Repositories
{
    public class WishListRepository
    {
        public IEnumerable<WishListItem> Get(int userId)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Query<WishListItem>("select * from WishListItems where UserId = @UserId", new { UserId = userId });
            }
        }

        public int Insert(WishListItem item)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Insert(item);
            }
        }
    }
}

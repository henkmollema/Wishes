using System.Collections.Generic;
using Dapper;
using Dommel;
using Wishes.Core.Domain.Model;

namespace Wishes.Core.Data.Repositories
{
    public class WishListRepository
    {
        public WishListItem Get(int id)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Get<WishListItem>(id);
            }
        }

        public IEnumerable<WishListItem> GetByUser(int userId)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Query<WishListItem>("select * from WishListItems where UserId = @UserId order by SortOrder", new { UserId = userId });
            }
        }

        public int Insert(WishListItem item)
        {
            using (var con = Database.GetOpenConnection())
            {
                return con.Insert(item);
            }
        }

        public void Update(WishListItem item)
        {
            using (var con = Database.GetOpenConnection())
            {
                con.Update(item);
            }
        }

        public void Remove(WishListItem item)
        {
            using (var con = Database.GetOpenConnection())
            {
                con.Delete(item);
            }
        }
    }
}

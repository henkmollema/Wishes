using System.Collections.Generic;
using System.Linq;
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

        public Dictionary<string, int> GetProductCount()
        {
            using (var con = Database.GetOpenConnection())
            {
                string sql = @"
select ProductName, count(*) as c from WishListItems
group by ProductName
order by c desc";
                var res = con.Query<dynamic>(sql);
                var dict = res.ToDictionary<dynamic, string, int>(item => item.ProductName, item => item.c);
                return dict;
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

        public void RemoveItem(WishListItem item)
        {
            using (var con = Database.GetOpenConnection())
            {
                con.Delete(item);
            }
        }

        public void RemoveList(int userId)
        {
            using (var con = Database.GetOpenConnection())
            {
                string sql = "delete from WishListItems where UserId = @UserId";
                con.Execute(sql, new { UserId = userId });
            }
        }
    }
}

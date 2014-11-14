using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wishes.Core.Data.Repositories;
using Wishes.Core.Domain.Model;
using Wishes.Web.Models.WishList;

namespace Wishes.Web.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly WishListRepository _wishListRepository = new WishListRepository();

        [Route("verlanglijstje")]
        public ActionResult Index()
        {
            var user = _userRepository.GetByName(User.Identity.Name);
            var model = PopulateModel(user);

            return View(model);
        }

        [HttpPost]
        public JsonResult AddItem(WishListModel model)
        {
            var user = CurrentUser;

            int id = _wishListRepository.Insert(new WishListItem
                                                    {
                                                        ProductName = model.Item.ProductName,
                                                        UserId = user.Id,
                                                        SortOrder = 9999
                                                    });

            return Json(new { success = true, id, item = model.Item.ProductName });
        }

        [HttpPost]
        public JsonResult RemoveItem(int id)
        {
            var item = _wishListRepository.Get(id);
            if (item == null)
            {
                return Json(new { success = false });
            }

            var user = CurrentUser;
            if (item.UserId != user.Id)
            {
                return Json(new { success = false });
            }

            _wishListRepository.Remove(item);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult MoveItem(int id1, int order1, int id2, int order2)
        {
            var item1 = _wishListRepository.Get(id1);
            var item2 = _wishListRepository.Get(id2);
            if (item1 == null || item2 == null)
            {
                return Json(new { success = false });
            }

            var user = CurrentUser;
            if (item1.UserId != user.Id || item2.UserId != user.Id)
            {
                return Json(new { success = false });
            }

            item1.SortOrder = order1;
            item2.SortOrder = order2;

            _wishListRepository.Update(item1);
            _wishListRepository.Update(item2);

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ChangeChimneySize(ChimneySize size)
        {
            var user = CurrentUser;
            user.ChimneySize = size;
            _userRepository.Update(user);

            return Json(new { success = true });
        }

        private User CurrentUser
        {
            get
            {
                return _userRepository.GetByName(User.Identity.Name);
            }
        }

        private WishListModel PopulateModel(User user)
        {
            return new WishListModel
                       {
                           User = user,
                           Item = new WishListItemModel(),
                           Items = GetItems(user.Id)
                       };
        }

        private IEnumerable<WishListItem> GetItems(int id)
        {
            var items = _wishListRepository.GetByUser(id).ToList();
            return items;
        }
    }
}

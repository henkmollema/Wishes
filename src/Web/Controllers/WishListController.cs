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
            var user = _userRepository.Get(User.Identity.Name);
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
                                                        SortOrder = 0
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
        public JsonResult MoveItem(int id, bool up)
        {
            return Json(new { success = true });
        }

        private User CurrentUser
        {
            get
            {
                return _userRepository.Get(User.Identity.Name);
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

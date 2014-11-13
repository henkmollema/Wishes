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


        [Route("verlanglijstje")]
        [HttpPost]
        public ActionResult Index(WishListModel model)
        {
            var user = _userRepository.Get(User.Identity.Name);

            _wishListRepository.Insert(new WishListItem
                                           {
                                               ProductName = model.Item.ProductName,
                                               UserId = user.Id,
                                               SortOrder = 0
                                           });

            return View(PopulateModel(user));
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
            var items = _wishListRepository.Get(id).ToList();
            return items;
        }
    }
}

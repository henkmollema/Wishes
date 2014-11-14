using System.Linq;
using System.Web.Mvc;
using Wishes.Core.Data.Repositories;
using Wishes.Web.Models.Admin;
using Wishes.Web.Models.WishList;

namespace Wishes.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly WishListRepository _wishListRepository = new WishListRepository();

        [Route("admin")]
        public ActionResult Index()
        {
            if (User.Identity.Name != WishesSettings.AdminUsername)
            {
                return new HttpUnauthorizedResult();
            }

            var model = new OverviewModel
                            {
                                Users = _userRepository.GetAll().ToList()
                            };

            return View(model);
        }

        [Route("admin/verlanglijstjes/{id}")]
        public ActionResult WishList(int id)
        {
            if (User.Identity.Name != WishesSettings.AdminUsername)
            {
                return new HttpUnauthorizedResult();
            }

            var items = _wishListRepository.GetByUser(id).ToList();
            var model = new WishListModel
                            {
                                User = _userRepository.Get(id),
                                Item = new WishListItemModel(),
                                Items = items
                            };

            return View(model);
        }

        [Route("admin/verlanglijstjes/{id}")]
        [HttpPost]
        public ActionResult WishList(FormCollection form, int id)
        {
            _wishListRepository.RemoveList(id);
            return RedirectToAction("Index");
        }

        [Route("cadeautjes")]
        public ActionResult ProductCount()
        {
            var dict = _wishListRepository.GetProductCount();
            return View(dict);
        }
    }
}

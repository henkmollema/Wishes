using System.Web.Mvc;
using Wishes.Web.Models.Account;

namespace Wishes.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("registreren")]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // todo: map to domain model and insert in db.

                return RedirectToAction("Create", "WishList");
            }
            return View(model);
        }
    }
}

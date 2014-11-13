using System.Web.Mvc;
using Wishes.Core.Data;
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
        [Route("registreren")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // todo: map to domain model and insert in db.
                using (var con = Database.GetOpenConnection())
                {
                    
                }

                return RedirectToAction("Create", "WishList");
            }
            return View(model);
        }
    }
}

using System.Web.Helpers;
using System.Web.Mvc;
using Wishes.Core.Data.Repositories;
using Wishes.Core.Domain.Model;
using Wishes.Web.Models.Account;

namespace Wishes.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();

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
                _userRepository.Insert(new User
                                           {
                                               Username = model.Username,
                                               Password = Crypto.HashPassword(model.Password),
                                               Name = model.Name,
                                               Address = model.Address,
                                               Zipcode = model.Zipcode,
                                               City = model.City,
                                               ChimneySize = (int)ChimneySize.Medium
                                           });

                return RedirectToAction("Create", "WishList");
            }
            return View(model);
        }
    }
}

using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
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
                                               ChimneySize = ChimneySize.Medium
                                           });

                FormsAuthentication.SetAuthCookie(model.Username, true);

                return RedirectToAction("Index", "WishList");
            }
            return View(model);
        }

        [Route("inloggen")]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [Route("inloggen")]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.Get(model.Username);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
                        return RedirectToAction("Index", "WishList");
                    }
                }

                ModelState.AddModelError("", "Gebruikersnaam of wachtwoord klopt niet.");
            }

            return View(model);
        }

        [Authorize]
        [Route("uitloggen")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

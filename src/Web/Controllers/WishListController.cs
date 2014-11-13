using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wishes.Web.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        [Route("verlanglijstje")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
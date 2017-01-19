using System.Web.Mvc;
using WebSample.Helpers;
using WebSample.ViewModels;

namespace WebSample.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(UserViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", model.ToRouteValueDictionary());
            }            
            return View(model);
        }        
    }
}
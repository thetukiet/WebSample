using System.Web.Mvc;
using WebSample.Data.Entities;
using WebSample.Helpers;
using WebSample.Services;
using WebSample.ViewModels;

namespace WebSample.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMemberService _memberService;

        public AccountController(IMemberService memberService)
        {
            _memberService = memberService;
        }

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
                var newMember = new Member
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    DoB = model.DoB.Value
                };
                if(_memberService.InsertOrUpdateMember(newMember) > 0)
                    return RedirectToAction("Index", model.ToRouteValueDictionary());
            }            
            return View(model);
        }        
    }
}
using MVCLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLibrary.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var values = context.Admin.FirstOrDefault(x => x.User == admin.User && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.User, false);
                Session["User"]=values.User.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
          
        }
    }
}
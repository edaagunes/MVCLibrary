using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class LoginController : Controller
    {
        LibraryDbEntities context=new LibraryDbEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Member member)
        {
            var values= context.Member.FirstOrDefault(x=>x.Mail==member.Mail && x.Password==member.Password);
            if (values !=null)
            {
                FormsAuthentication.SetAuthCookie(values.Mail, false);
                Session["Mail"]=values.Mail.ToString();
              
                return RedirectToAction("Index","MemberPanel");
            }
            else
            {
                return View();
            }
          
        }
    }
}
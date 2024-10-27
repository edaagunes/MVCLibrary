using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class RegisterController : Controller
    {
        LibraryDbEntities context=new LibraryDbEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            context.Member.Add(member);
            context.SaveChanges();
            return View();
        }
    }
}
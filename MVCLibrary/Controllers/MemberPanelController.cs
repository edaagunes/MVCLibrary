using MVCLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class MemberPanelController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
       
        [Authorize]
        public ActionResult Index()
        {
            var memberMail = (string)Session["Mail"];
            var values = context.Member.FirstOrDefault(x => x.Mail == memberMail);
            return View(values);
        }
        [HttpPost]
        public ActionResult MemberProfile(Member p)
        {
            var value = (string)Session["Mail"];
            var member = context.Member.FirstOrDefault(x => x.Mail == value);
            member.Password = p.Password;
            member.Name = p.Name;
            member.Surname = p.Surname;
            member.Photo = p.Photo;
            member.Phone = p.Phone;
            member.School = p.School;
            member.Username = p.Username;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
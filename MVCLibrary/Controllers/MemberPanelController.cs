using MVCLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLibrary.Controllers
{
    public class MemberPanelController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();

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

        public ActionResult MemberBooks()
        {
            var value = (string)Session["Mail"];
            var member = context.Member.Where(x => x.Mail == value.ToString()).Select(x=>x.MemberID).FirstOrDefault();
            var values = context.Sale.Where(x => x.Member==member).ToList();
            return View(values);
        }

        public ActionResult Notice()
        {
            var noticeList=context.Announcement.ToList();
            return View(noticeList);
        }


    }
}
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
            //var values = context.Member.FirstOrDefault(x => x.Mail == memberMail);
            
            ViewBag.name=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.Name+" "+x.Surname).FirstOrDefault();
            ViewBag.photo=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.Photo).FirstOrDefault();
            ViewBag.username=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.Username).FirstOrDefault();
            ViewBag.school=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.School).FirstOrDefault();
            ViewBag.phone=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.Phone).FirstOrDefault();
            ViewBag.mail=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.Mail).FirstOrDefault();
            var memberId=context.Member.Where(x=>x.Mail == memberMail).Select(x=>x.MemberID).FirstOrDefault();
            ViewBag.book = context.Sale.Where(x => x.Member == memberId).Count();
            ViewBag.message = context.Message.Where(x => x.Receiver == memberMail).Count();
            ViewBag.notice = context.Announcement.Count();
            return View();
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

        public PartialViewResult PartialNotice()
        {
            var values = context.Announcement.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSettings()
        {
            var mail = (string)Session["Mail"];
            var id=context.Member.Where(x=>x.Mail==mail).Select(x=>x.MemberID).FirstOrDefault();
            var member = context.Member.Find(id);
            return PartialView("PartialSettings",member);
        }
    }
}
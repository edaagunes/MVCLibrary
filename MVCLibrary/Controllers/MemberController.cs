using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCLibrary.Controllers
{
    public class MemberController : Controller
    {
        LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index(int page = 1)
        {
            var values = context.Member.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            context.Member.Add(member);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMember(int id)
        {
            var values = context.Member.Find(id);
            context.Member.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            var values = context.Member.Find(id);
            return View("UpdateMember", values);
        }

        [HttpPost]
        public ActionResult UpdateMember(Member member)
        {
            var values = context.Member.Find(member.MemberID);
            values.Name = member.Name;
            values.Surname = member.Surname;
            values.Mail = member.Mail;
            values.Username = member.Username;
            values.Password = member.Password;
            values.Photo = member.Photo;
            values.Phone = member.Phone;
            values.School = member.School;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class AnnouncementController : Controller
    {
        LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index()
        {
            var values = context.Announcement.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddNotice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNotice(Announcement notice)
        {
            context.Announcement.Add(notice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteNotice(int id)
        {
            var values=context.Announcement.Find(id);
            context.Announcement.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailNotice(Announcement announcement)
        {
            var values=context.Announcement.Find(announcement.Id); 
            return View(values);
        }

        public ActionResult UpdateNotice(Announcement announcement)
        {
            var values = context.Announcement.Find(announcement.Id);
            values.Content = announcement.Content;
            values.Date=announcement.Date;
            values.Category=announcement.Category;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
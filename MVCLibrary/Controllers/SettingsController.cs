using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class SettingsController : Controller
    {
        LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index()
        {
            var values=context.Admin.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAdmin(Admin admin)
        {
            context.Admin.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values=context.Admin.Find(id);
            context.Admin.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = context.Admin.Find(id);
            return View("UpdateAdmin",values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var values = context.Admin.Find(admin.Id);
            values.User=admin.User;
            values.Password=admin.Password;
            values.Authority=admin.Authority;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
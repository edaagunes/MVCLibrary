using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;
namespace MVCLibrary.Controllers
{
    public class StaffController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Index()
        {
            var values = context.Staff.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaff");
            }
            context.Staff.Add(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStaff(int id)
        {
            var values = context.Staff.Find(id);
            context.Staff.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStaff(int id)
        {
            var values = context.Staff.Find(id);
            return View("UpdateStaff", values);
        }

        [HttpPost]
        public ActionResult UpdateStaff(Staff p)
        {
            var values = context.Staff.Find(p.StaffID);
            values.Name = p.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
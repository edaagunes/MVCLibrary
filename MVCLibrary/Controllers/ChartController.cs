using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class ChartController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BooksCategory()
        {
            var data = context.Category
                   .Where(c => c.Book.Count>0)
                   .Select(c => new
                   {
                       CategoryName = c.Name,
                       BookCount = c.Book.Count
                   })
                   .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PublishingHouse()
        {
            var data = context.Book
                   .GroupBy(c => c.PublishingHouse)
                   .Select(c => new
                   {
                       PublishingHouseName = c.Key,
                       BookCount = c.Count()
                   })
                   .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MemberSchool()
        {
            var data = context.Member
                   .GroupBy(c => c.School)
                   .Select(c => new
                   {
                       SchoolName = c.Key,
                       MemberCount = c.Count()
                   })
                   .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class CategoryController : Controller
    {
        LibraryDbEntities context= new LibraryDbEntities();
        public ActionResult Index(int page=1)
        {
            var values=context.Category.Where(x=>x.Status==true).ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category ctg)
        {
            context.Category.Add(ctg);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var values= context.Category.Find(id);
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.Category.Find(id);
            return View("UpdateCategory",values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            var values = context.Category.Find(p.CategoryID);
            values.Name = p.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
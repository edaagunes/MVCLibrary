using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;
using MVCLibrary.Models.Classes;

namespace MVCLibrary.Controllers
{
    public class ShowcaseController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = context.Book.Take(6).ToList();
            cs.Value2 = context.About.ToList();

            //var values=context.Book.Take(6).ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            context.Contact.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
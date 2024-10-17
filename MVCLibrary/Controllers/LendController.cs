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
    public class LendController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Index(string p, int page = 1)
        {
            var values = context.Sale.Where(x => x.Book1.Name.Contains(p) || p == null || x.Member1.Name.Contains(p) || x.Member1.Surname.Contains(p)).ToList().ToPagedList(page, 6);

            return View(values);
        
        }
        [HttpGet]
        public ActionResult LendBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LendBook(Sale sale)
        {
            context.Sale.Add(sale);
            context.SaveChanges();
            return RedirectToAction("LendBook");
        }
    }
}
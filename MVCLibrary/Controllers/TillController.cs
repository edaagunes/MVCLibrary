using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class TillController : Controller
    {
       LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index()
        {
            ViewBag.till=context.Penalty.Sum(x=>x.Money).ToString();
            return View();
        }
    }
}
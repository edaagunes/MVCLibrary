using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class TransactionsController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Index()
        {
            var values=context.Sale.Where(x=>x.SaleState==true).ToList();
            return View(values);
        }


    }
}
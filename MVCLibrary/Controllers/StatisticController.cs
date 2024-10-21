using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult WeatherWidget()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file.ContentLength >0)
            {
                string filepath=Path.Combine(Server.MapPath("~/web2/photos/"),Path.GetFileName(file.FileName));
                file.SaveAs(filepath);
            }
            return RedirectToAction("Gallery");
        }
    }
}
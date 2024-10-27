using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class StatisticController : Controller
    {
       LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index()
        {
            ViewBag.memberCount = context.Member.Count();
            ViewBag.bookCount=context.Book.Count();
            ViewBag.lendBook=context.Book.Where(x=>x.Status==false).Count();
            ViewBag.money=context.Penalty.Sum(x=>x.Money);
            return View();
        }

        public ActionResult LinqCard()
        {
            ViewBag.memberCount = context.Member.Count();
            ViewBag.bookCount = context.Book.Count();
            ViewBag.lendBook = context.Book.Where(x => x.Status == false).Count();
            ViewBag.money = context.Penalty.Sum(x => x.Money);
            ViewBag.category=context.Category.Count();
            ViewBag.message=context.Contact.Count();
            ViewBag.mostAuthor = context.MostBookAuthor().FirstOrDefault();
            ViewBag.publicationHouse=context.Book.GroupBy(x=>x.PublishingHouse).OrderByDescending(z=>z.Count()).Select(y=> y.Key).FirstOrDefault();

            // Bugünki Ödünç Verilen Kitaplar
            ViewBag.borrowBookToday=context.Sale.Where(x=>x.MemberReturnDate==DateTime.Today).Count();

            // En Başarılı Personel
            var mostStaffId=context.Sale.GroupBy(x=>x.Staff1.StaffID).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.mostStaff=context.Sale.Where(x=>x.Staff1.StaffID==mostStaffId).Select(y=>y.Staff1.Name).FirstOrDefault();

            // En Aktif Üye
            var mostMemberId = context.Sale.GroupBy(x => x.Member1.MemberID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.mostMember=context.Sale.Where(x=>x.Member1.MemberID==mostMemberId).Select(y=>y.Member1.Name +" "+ y.Member1.Surname).FirstOrDefault();

            // En Çok Okunan Kitap
            var mostBookId = context.Sale.GroupBy(x => x.Book1.BookID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.mostBook=context.Sale.Where(x=>x.Book1.BookID==mostBookId).Select(y=>y.Book1.Name).FirstOrDefault();

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
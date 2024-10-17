using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var values = context.Sale.Where(x => (x.Book1.Name.Contains(p) || p == null || x.Member1.Name.Contains(p) || x.Member1.Surname.Contains(p))
                    && x.SaleState == false).ToList().ToPagedList(page, 6);

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
            //context.Sale.Add(sale);
            //context.SaveChanges();
            //return RedirectToAction("LendBook");

            // Kitabı ID'ye göre veritabanından getir
            var book = context.Book.FirstOrDefault(b => b.BookID == sale.Book1.BookID);
            var member = context.Member.FirstOrDefault(m => m.MemberID == sale.Member1.MemberID);
            var staff = context.Staff.FirstOrDefault(s => s.StaffID == sale.Staff1.StaffID);

            if (book != null && member != null && staff != null)
            {
                sale.Book1 = book;  // Mevcut kitap varlığını ata
                sale.Member1 = member;  // Mevcut üye varlığını ata
                sale.Staff1 = staff;  // Mevcut personel varlığını ata

                sale.AcquisitionDate = DateTime.Now;  // Alış tarihini ata
                sale.SaleState = false;  // Kitap hala ödünçte anlamında false yap

                context.Sale.Add(sale);
                context.SaveChanges();
            }
            else
            {
                // Eğer herhangi bir varlık bulunamazsa hata durumunu yönet
                ViewBag.ErrorMessage = "Geçersiz kitap, üye veya personel bilgisi.";
                return View();
            }

            return RedirectToAction("LendBook");
        }
    

        public ActionResult BorrowBook(int id)
        {
            var values = context.Sale.Find(id);
            return View("BorrowBook", values);
        }

        public ActionResult UpdateBorrow(Sale sale)
        {
            var values = context.Sale.Find(sale.SaleID);
            //values.MemberReturnDate = sale.MemberReturnDate;
            //values.SaleState = true;
            if (values != null)
            {
                values.MemberReturnDate = sale.MemberReturnDate;  // MemberReturnDate alanını güncelle
                values.SaleState = true;  // Kitap iade edildi olarak işaretle

                context.SaveChanges();  // Değişiklikleri veritabanına kaydet
            }

            context.SaveChanges();
            return RedirectToAction("Index","Lend");
        }
    }
}
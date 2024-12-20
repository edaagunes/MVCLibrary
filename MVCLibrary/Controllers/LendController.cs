﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace MVCLibrary.Controllers
{
    [Authorize(Roles = "A")]
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
            List<SelectListItem> value=(from x in context.Member.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name +" "+x.Surname,
                                            Value=x.MemberID.ToString(),
                                        }).ToList();

            List<SelectListItem> value2 = (from x in context.Book.Where(x=>x.Status==true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.BookID.ToString(),
                                          }).ToList();

            List<SelectListItem> value3 = (from x in context.Staff.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.StaffID.ToString(),
                                           }).ToList();
            ViewBag.member=value;
            ViewBag.book=value2;
            ViewBag.staff=value3;
            return View();
        }

        [HttpPost]
        public ActionResult LendBook(Sale sale)
        {
            var member = context.Member.Where(x => x.MemberID == sale.Member1.MemberID).FirstOrDefault();
            var book = context.Book.Where(x => x.BookID == sale.Book1.BookID).FirstOrDefault();
            var staff = context.Staff.Where(x => x.StaffID == sale.Staff1.StaffID).FirstOrDefault();


            // Kitabı ID'ye göre veritabanından getir
            //var book = context.Book.FirstOrDefault(b => b.BookID == sale.Book1.BookID);
            //var member = context.Member.FirstOrDefault(m => m.MemberID == sale.Member1.MemberID);
            //var staff = context.Staff.FirstOrDefault(s => s.StaffID == sale.Staff1.StaffID);

            if (book != null && member != null && staff != null)
            {
                sale.Book1 = book;  // Mevcut kitap varlığını ata
                sale.Member1 = member;  // Mevcut üye varlığını ata
                sale.Staff1 = staff;  // Mevcut personel varlığını ata

                sale.AcquisitionDate = DateTime.Now;  // Alış tarihini ata
                sale.SaleState = false;  // Kitap hala ödünçte anlamında false yap

                context.Sale.Add(sale);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer herhangi bir varlık bulunamazsa hata durumunu yönet
                ViewBag.ErrorMessage = "Geçersiz kitap, üye veya personel bilgisi.";
                return View();
            }

            
        }
    

        public ActionResult BorrowBook(int id)
        {
            // İlgili verileri dahil ediyoruz (Kitap, Üye, Personel gibi ilişkili tablolar)
            var values = context.Sale.Include(s => s.Book1).Include(s => s.Member1).Include(s => s.Staff1).FirstOrDefault(s=>s.SaleID==id);

            // Eğer değer null ise, kullanıcıya bir hata mesajı verin
            if (values == null)
            {
                ViewBag.Message = "Geçersiz satış kaydı.";
                return View("BorrowBook");
            }

            // ReturnDate boş değilse geç gelen gün sayısını hesapla
            if (values.ReturnDate != null)
            {
                DateTime d1 = DateTime.Parse(values.ReturnDate.ToString());
                DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                TimeSpan d3 = d2 - d1;
                ViewBag.value1 = d3.TotalDays;
            }
            else
            {
                // Eğer iade tarihi yoksa, 0 gün geç gelmiş sayabiliriz
                ViewBag.value1 = 0;
            }

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
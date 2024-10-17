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
    public class BookController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Index(string p,int page=1)
        {
          //  var values = context.Book.ToList();
          var values=context.Book.Where(x=>x.Name.Contains(p) || p==null || x.Author1.Name.Contains(p)||x.Author1.Surname.Contains(p)).ToList().ToPagedList(page,6);

            return View(values);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categories = (from i in context.Category.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            List<SelectListItem> authors = (from i in context.Author.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name + ' ' + i.Surname,
                                                Value = i.AuthorID.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            var category = context.Category.Where(x => x.CategoryID == book.Category1.CategoryID).FirstOrDefault();
            var author = context.Author.Where(y => y.AuthorID == book.Author1.AuthorID).FirstOrDefault();
            book.Category1 = category;
            book.Author1 = author;
            book.Status = true;
            context.Book.Add(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var values = context.Book.Find(id);
            context.Book.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var values = context.Book.Find(id);
            List<SelectListItem> categories = (from i in context.Category.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            List<SelectListItem> authors = (from i in context.Author.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name + ' ' + i.Surname,
                                                Value = i.AuthorID.ToString()
                                            }).ToList();
            ViewBag.authors = authors;

            return View("UpdateBook", values);
        }

        [HttpPost]
        public ActionResult UpdateBook(Book book)
        {
            var values = context.Book.Find(book.BookID);
            values.Name = book.Name;
            values.PublicationYear = book.PublicationYear;
            values.PublishingHouse = book.PublishingHouse;
            values.Page = book.Page;
            book.Status = true;
            var category=context.Category.Where(x=>x.CategoryID==book.Category1.CategoryID).FirstOrDefault();
            var author=context.Author.Where(y=>y.AuthorID==book.Author1.AuthorID).FirstOrDefault();
            book.Category = category.CategoryID;
            book.Author = author.AuthorID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
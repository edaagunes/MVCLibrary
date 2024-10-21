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
    public class AuthorController : Controller
    {
       LibraryDbEntities context=new LibraryDbEntities();
        public ActionResult Index(int page=1)
        {
            var values=context.Author.ToList().ToPagedList(page,4);
            return View(values);
        }

        public ActionResult DeleteAuthor(int id)
        {
            var values = context.Author.Find(id);
            context.Author.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var values=context.Author.Find(id);
            return View("UpdateAuthor",values);
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
            var values = context.Author.Find(author.AuthorID);
            values.Name = author.Name;
            values.Surname = author.Surname;
            values.Detail = author.Detail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]   
        public ActionResult AddAuthor()
        {
           return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author a)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            context.Author.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
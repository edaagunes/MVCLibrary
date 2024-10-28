using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Controllers
{
    public class MessageController : Controller
    {
        LibraryDbEntities context = new LibraryDbEntities();
        public ActionResult Inbox()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var values = context.Message.Where(x => x.Receiver == memberMail.ToString()).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var memberMail = (string)Session["Mail"].ToString();
            message.Sender = memberMail.ToString();
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("NewMessage");
        }

        public ActionResult OutBox()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var values = context.Message.Where(x => x.Sender == memberMail.ToString()).ToList();
            return View(values);
        }
    }
}
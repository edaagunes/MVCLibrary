using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class MemberPanelController : Controller
    {
        // GET: MemberPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}
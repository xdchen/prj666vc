using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prj666vc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult VirtualClass()
        {
            ViewBag.Message = "Your vc description page.";

            return View();
        }

        public ActionResult NotesSharing()
        {
            ViewBag.Message = "Your NS page.";

            return View();
        }
    }
}

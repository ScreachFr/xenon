using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Xenon___Allianz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (((string)Session["XenonType"]).Equals("admin"))
            {
                return Redirect("/Admin");
            }
            return Redirect("/Wallet");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
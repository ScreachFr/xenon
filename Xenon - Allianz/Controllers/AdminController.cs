using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return Redirect("/Admin/Wallets");
        }
        
        public ActionResult Users()
        {
            return View(Database.users);
        }

        public ActionResult Wallets()
        {
            return View(Database.wallets);
        }
        public ActionResult Contracts()
        {
            return View(Database.contracts);
        }

    }
}
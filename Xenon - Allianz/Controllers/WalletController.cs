using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class WalletController : Controller
    {
        List<WalletModel> wallets = new List<WalletModel>();
        // GET: Wallet
        public ActionResult Index()
        {
            int userId = (int)(Session["XenonUserId"]);
            Console.Write(userId);
            return View(Database.GetWalletByScope(userId));
        }

        public ActionResult Edit(String id)
        {
            ViewBag.Service = id;
            

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddWallet(WalletModel w)
        {
            Database.AddWallet(w);
            return Redirect("/Wallet");
        }
        
    }
}
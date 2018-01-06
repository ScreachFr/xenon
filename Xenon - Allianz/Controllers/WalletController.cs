using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.Models;
using Xenon___Allianz.DataAccess;

namespace Xenon___Allianz.Controllers
{
    public class WalletController : Controller
    {
        List<WalletModel> wallets = new List<WalletModel>();
        // GET: Wallet
        public ActionResult Index()
        {
            Guid userId = (Guid)(Session["XenonUserId"]);
            Console.Write(userId);
            //Session["currentWallet"] = null;
            return View(DataAccessAction.wallet.GetWalletByScope(userId));
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
            Guid userId = (Guid)(Session["XenonUserId"]);
            //Database.AddWallet(w, userId);
            DataAccessAction.wallet.AddWallet(w, userId);
            return Redirect("/Wallet");
        }
        
    }
}
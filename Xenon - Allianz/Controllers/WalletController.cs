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
            /*wallets.Add(new WalletModel { Service = "Health" });
            wallets.Add(new WalletModel { Service = "Defense" });
            wallets.Add(new WalletModel { Service = "Sport" });
            */
            return View(Database.wallets);
        }

        public ActionResult Edit(String id)
        {
            ViewBag.Service = id;
            /*
            WalletModel w = null;
            foreach (var item in Database.wallets)
            {
                if (item.Equals(id))

                    return View();
            }
            */

            return View();
            //return Redirect("/Wallet");//View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddWallet(WalletModel w)
        {
            Database.wallets.Add(w);
            return Redirect("/Wallet");
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class WalletController : Controller
    {

        // GET: Wallet
        public ActionResult Index()
        {
            Guid userId = (Guid)(Session["XenonUserId"]);
            List<WalletModel> wallets = new List<WalletModel>();
            Console.Write(userId);
            //Session["currentWallet"] = null;
            foreach (var item in DataAccessAction.wallet.GetWalletByScope(userId))
            {
                wallets.Add(new WalletModel { Id = item.Id, Service = item.Service, numberOfContract = 0 });
            }
            foreach (var item in wallets)
            {
                item.numberOfContract = DataAccessAction.wallet.NumberOfContractsByWalletId(item.Id);
            }
            return View(wallets);
        }

        public ActionResult Edit(String id)
        {
            ViewBag.Service = id;


            return View();
        }

        public ActionResult Create()
        {
            string status = (string)(Session["XenonStatus"]);

            if (status.Equals("souscripteur")) {
                return View();
            }
            return Redirect("/Wallet");

        }
        public ActionResult AddWallet(WalletModel wm)
        {

            Guid userId = (Guid)(Session["XenonUserId"]);
            //Database.AddWallet(w, userId);
            Wallet w = new Wallet { Id = new Guid(), Service = wm.Service };
            DataAccessAction.wallet.AddWallet(w, userId);
            return Redirect("/Wallet");
        }

    }
}
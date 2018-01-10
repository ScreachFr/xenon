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
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            Guid userId = (Guid)(Session["XenonUserId"]);
            string connectedSession = (string)(Session["XenonStatus"]);
            List<WalletModel> walletModels = new List<WalletModel>();
            List<Wallet> wallets = null;
            if (connectedSession.Equals("souscripteur") || connectedSession.Equals("manager"))
            {
                wallets = DataAccessAction.wallet.GetWalletByScope(userId);
            }
            else
            {
                wallets = DataAccessAction.wallet.GetAllWallet();
            }
            foreach (var item in wallets)
            {
                walletModels.Add(new WalletModel { Id = item.Id, Service = item.Service, numberOfContract = 0 });
            }
            foreach (var item in walletModels)
            {
                item.numberOfContract = DataAccessAction.wallet.NumberOfContractsByWalletId(item.Id);
            }


            //Console.Write(userId);
            //Session["currentWallet"] = null;

            return View(walletModels);
        }

        public ActionResult Edit(String id)
        {
            ViewBag.Service = id;


            return View();
        }

        public ActionResult Create()
        {
            string status = (string)(Session["XenonStatus"]);

            if (status.Equals("souscripteur"))
            {
                return View();
            }
            return Redirect("/Wallet");

        }
        public ActionResult AddWallet(WalletModel wm)
        {

            Guid userId = (Guid)(Session["XenonUserId"]);
            //Database.AddWallet(w, userId);
            Wallet w = new Wallet { Service = wm.Service };
            DataAccessAction.wallet.AddWallet(w, userId);
            return Redirect("/Wallet");
        }

    }
}
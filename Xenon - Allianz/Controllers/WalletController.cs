using Newtonsoft.Json;
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
            return View(GetWalletsByUserScope());
        }

       

        public List<WalletModel> GetWalletsByUserScope()
        {
            List<WalletModel> walletModels = new List<WalletModel>();
            if (Session["XenonUserId"] != null)
            {

                Guid userId = (Guid)(Session["XenonUserId"]);
                string connectedSession = (string)(Session["XenonStatus"]);
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
            }
            return walletModels;
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

            AddWalletAux(wm);
            return Redirect("/Wallet");
        }
        private void AddWalletAux(WalletModel wm)
        {
            Guid userId = (Guid)(Session["XenonUserId"]);
            //Database.AddWallet(w, userId);
            Wallet w = new Wallet { Service = wm.Service };
            DataAccessAction.wallet.AddWallet(w, userId);
        }

        /** API WEB SERVICE **/

        public string GetWalletsByUserScopeApi()
        {
            return JsonConvert.SerializeObject(GetWalletsByUserScope());
        }

        public void AddWalletApi(String service)
        {
            WalletModel wm = new WalletModel
            {
                Service = service
            };
            AddWalletAux(wm);
        }

    }
}
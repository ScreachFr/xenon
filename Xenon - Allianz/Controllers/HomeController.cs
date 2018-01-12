using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon___Allianz.DataAccess;

namespace Xenon___Allianz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["XenonStatus"] != null)
            {
                if (((string)Session["XenonStatus"]).Equals("admin"))
                {
                    return Redirect("/Admin");
                }
                return Redirect("/Wallet");
                /*List<WalletModel> wallets = new List<WalletModel>();
                foreach (var item in DataAccessAction.wallet.GetAllWallet())
                {
                    wallets.Add(new WalletModel()
                    {
                        Id = item.Id,
                        Service = item.Service
                    });
                }
                List<ContractModel> contracts = new List<ContractModel>();
                HomePageModel hpm = new HomePageModel()
                {
                    Contracts = contracts,
                    Wallets = wallets
                };
                return View(hpm);
                */
            }
            return Redirect("/");
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
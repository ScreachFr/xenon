using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon___Allianz.DataAccess;

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

        public ActionResult RegisterUser()
        {
            return View();
        }
        public ActionResult RegisterUserAux(UserModel user)
        {
            DataAccessAction.user.Register(user);
            return Redirect("/Admin/Users");
        }
        public ActionResult AddWallet()
        {
            return View();
        }
        public ActionResult AddWalletAux(WalletModel w)
        {
            DataAccessAction.wallet.AddWallet(w, 1);
            return Redirect("/Admin/Wallets");
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.DataAccess;

using Xenon.BusinessLogic.Models;
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
            if (((string)Session["XenonStatus"]).Equals("admin"))
            {


                List<UserModel> lu = new List<UserModel>();
                foreach (var item in DataAccessAction.user.GetAllUsers())
                {
                    lu.Add(new UserModel()
                    {
                        Id = item.Id,
                        Username = item.Username,
                        Mail = item.Mail,
                        Status = item.Status,
                        GeographicZone = item.GeographicZone,
                        GeographicZoneName = DataAccessAction.geographicZone.GetGeographicZoneById(item.GeographicZone).Name

                    });
                }
                return View(lu);
            }
            return Redirect("/");


        }

        public ActionResult Wallets()
        {
            if (((string)Session["XenonStatus"]).Equals("admin"))
            {
                List<WalletModel> lw = new List<WalletModel>();
                foreach (var item in DataAccessAction.wallet.GetAllWallet())
                {
                    lw.Add(new WalletModel()
                    {
                        Id = item.Id,
                        Service = item.Service,
                        numberOfContract = 0,
                    });
                }
                return View(lw);
            }
            return Redirect("/");
        }
        public ActionResult Contracts()
        {
            
            if (((string)Session["XenonStatus"]).Equals("admin"))
            {
                List<ContractModel> lc = new List<ContractModel>();
                foreach (var item in DataAccessAction.contract.GetAllContract())
                {
                    lc.Add(new ContractModel()
                    {
                        Id = item.Id,
                        Company = item.Company,
                        Cover = item.Cover,
                        End = item.End.ToString().Split(' ')[0],
                        Negociable = item.Negociable,
                        Prime = item.Prime,
                        Rompu = item.Rompu,
                        Start = item.Start.ToString().Split(' ')[0],
                        Value = item.Value,
                        Wallet = item.Wallet,
                        WalletName = DataAccessAction.wallet.GetWalletById(item.Wallet).Service,
                        Position =item.Position
                    });
                }
                return View(lc);
            }
            return Redirect("/");
        }

        public ActionResult RegisterUser()
        {
            return View();
        }
        public ActionResult RegisterUserAux(UserModel user)
        {
            User u = new User()
            {
                Id = new Guid(),
                Username = user.Username,
                Password = user.Password,
                Mail = user.Mail,
                Status = user.Status,
                GeographicZone = new Guid(),
            };
            DataAccessAction.user.Register(u);
            return Redirect("/Admin/Users");
        }
        public ActionResult AddWallet()
        {
            return View();
        }
        public ActionResult AddWalletAux(WalletModel w)
        {
            //DataAccessAction.wallet.AddWallet(w, new Guid()); // TODO Change this.
            return Redirect("/Admin/Wallets");
        }

        public ActionResult UpdateSatus()
        {
            return View();
        }
        public ActionResult UpdateStatusValidation(UpdateStatusModel usm)
        {
            if (((string)Session["XenonStatus"]).Equals("admin"))
            {
                return Redirect("/Admin/Users");
            }
            return Redirect("/");

        }



    }
}
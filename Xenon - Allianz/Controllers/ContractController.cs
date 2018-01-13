using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon___Allianz.DataAccess;
using Xenon.BusinessLogic.Models;
namespace Xenon___Allianz.Controllers

{
    public class ContractController : Controller
    {

        // GET: Contract
        public ActionResult Index(PaginationModel pm)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            if (((string)Session["XenonStatus"]).Equals("souscripteur") || 
                ((string)Session["XenonStatus"]).Equals("manager"))
            {

                List<ContractModel> l = new List<ContractModel>();

                foreach (var item in DataAccessAction.contract.GetContractByWalletId(pm.WalletId,pm.Page,pm.NumberOfElementsByPage))
                {
                    l.Add(new ContractModel()
                    {
                        Id = item.Id,
                        Start = item.Start.ToString(),
                        End = item.End.ToString(),
                        Cover = item.Cover,
                        Negociable = item.Negociable,
                        Prime = item.Prime,
                        Rompu = item.Rompu,
                        Company = item.Company,
                        Wallet = item.Wallet,
                        WalletName = "",
                        Value = item.Value
                    });
                }
                Session["currentWallet"] = pm.WalletId;
                ViewBag.service = pm.WalletId;
                ContractListModel clm = new ContractListModel()
                {
                    ContractList = l,
                    NumberOfContractInWallet = DataAccessAction.wallet.NumberOfContractsByWalletId(pm.WalletId)
                };

                return View(clm);
            }
            return Redirect("/");
        }
        public ActionResult ContractAtPage(PaginationModel pm)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            
            if (((string)Session["XenonStatus"]).Equals("souscripteur") ||
                ((string)Session["XenonStatus"]).Equals("manager"))
            {

                List<ContractModel> l = new List<ContractModel>();

                Console.WriteLine(pm);

                foreach (var item in DataAccessAction.contract.GetContractByWalletId(pm.WalletId, pm.Page, pm.NumberOfElementsByPage))
                {
                    l.Add(new ContractModel()
                    {
                        Id = item.Id,
                        Start = item.Start.ToString(),
                        End = item.End.ToString(),
                        Cover = item.Cover,
                        Negociable = item.Negociable,
                        Prime = item.Prime,
                        Rompu = item.Rompu,
                        Company = item.Company,
                        Wallet = item.Wallet,
                        WalletName = "",
                        Value = item.Value
                    });
                }
                Session["currentWallet"] = pm.WalletId;
                ViewBag.service = pm.WalletId;
                return View("index", l);
            }
            return Redirect("/");
        }

        public ActionResult Create(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            ViewBag.Wallet = id;
            Session["currentWallet"] = id;
            return View();
        }

        public ActionResult AddContract(ContractModel c)
        {
            Guid s = (Guid)Session["currentWallet"];
            c.Wallet = s;
            Contract contract = new Contract()
            {
                Start = new DateTime(
                    int.Parse(c.Start.Split('/')[2]), int.Parse(c.Start.Split('/')[0]), int.Parse(c.Start.Split('/')[1])),
                End = new DateTime(
                    int.Parse(c.End.Split('/')[2]), int.Parse(c.End.Split('/')[0]), int.Parse(c.End.Split('/')[1])),
                Cover = c.Cover,
                Negociable = c.Negociable,
                Prime = c.Prime,
                Rompu = c.Rompu,
                Company = c.Company,
                Value = c.Value,
                Wallet = s,
                Position = DataAccessAction.wallet.NumberOfContractsByWalletId(c.Wallet) + 1
            };
            DataAccessAction.contract.AddContract(contract);
            Console.WriteLine(c);
            //c.Wallet = Session["currentWallet"].ToString();
            //Database.contracts.Add(c);
            //DataAccessAction.contract.AddContract(c);
            return Redirect("/Wallet");
        }

        public ActionResult Detail(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            Contract item = DataAccessAction.contract.GetContractById(id);
            ContractModel contract =new ContractModel()
            {
                Id = item.Id,
                Start = item.Start.ToString(),
                End = item.End.ToString(),
                Cover = item.Cover,
                Negociable = item.Negociable,
                Prime = item.Prime,
                Rompu = item.Rompu,
                Company = item.Company,
                Wallet = item.Wallet,
                WalletName = DataAccessAction.wallet.GetWalletById(item.Wallet).Service,
                Value = item.Value
            };

            //contract.WalletName = ;
            
              
            return View(contract);
        }
    }


}
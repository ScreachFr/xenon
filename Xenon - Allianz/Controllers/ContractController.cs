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
        public ActionResult Index(Guid id)
        {
            List<ContractModel> l = new List<ContractModel>();
            //var eve = ctx.Evenements.Where(e => e.jourHeure.Day == d.Day).OrderBy(e => e.jourHeure).ToList();
            //List<ContractModel> l = Database.contracts.Where(e => e.Wallet.Equals(id)).ToList();


            // Database.getContractsByWalletService(string id);
            /*if(Session["currentWallet"] != null)
            {
                return Redirect("Contract/Index/" + ((int)Session["currentWallet"]));
            }*/
            foreach (var item in DataAccessAction.contract.GetContractByWalletId(id))
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
            Session["currentWallet"] = id;
            ViewBag.service = id;
            return View(l);
        }

        public ActionResult Create(Guid id)
        {
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
                Wallet = s
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
                WalletName = "",
                Value = item.Value
            };
            
              
            return View(contract);
        }
    }


}
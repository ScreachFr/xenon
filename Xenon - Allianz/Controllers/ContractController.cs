using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.Models;
using Xenon___Allianz.DataAccess;
namespace Xenon___Allianz.Controllers
{
    public class ContractController : Controller
    {

        // GET: Contract
        public ActionResult Index(Guid id)
        {
            //List<ContractModel> l = new List<ContractModel>();
            //var eve = ctx.Evenements.Where(e => e.jourHeure.Day == d.Day).OrderBy(e => e.jourHeure).ToList();
            //List<ContractModel> l = Database.contracts.Where(e => e.Wallet.Equals(id)).ToList();


            // Database.getContractsByWalletService(string id);
            /*if(Session["currentWallet"] != null)
            {
                return Redirect("Contract/Index/" + ((int)Session["currentWallet"]));
            }*/
            Session["currentWallet"] = id;
            ViewBag.service = id;
            return View(DataAccessAction.contract.GetContractByWalletId(id));
        }

        public ActionResult Create(int id)
        {
            ViewBag.Wallet = id;
            Session["currentWallet"] = id;
            return View();
        }

        public ActionResult AddContract(ContractModel c)
        {
            Guid s = (Guid)Session["currentWallet"];
            c.Wallet = s;

            Console.WriteLine(c);
            //c.Wallet = Session["currentWallet"].ToString();
            //Database.contracts.Add(c);
            DataAccessAction.contract.AddContract(c);
            return Redirect("/Wallet");
        }

        public ActionResult Detail(Guid id)
        {
            ContractModel c = DataAccessAction.contract.GetContractById(id);
            if (c == null)
            {
                return Redirect("/");
            }
            return View(c);
        }
    }


}
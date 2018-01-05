using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;
namespace Xenon___Allianz.Controllers
{
    public class ContractController : Controller
    {

        // GET: Contract
        public ActionResult Index(int id)
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
            int s = (int)(Session["currentWallet"]);
            c.Wallet = s;

            Console.WriteLine(c);
            //c.Wallet = Session["currentWallet"].ToString();
            //Database.contracts.Add(c);
            DataAccessAction.contract.AddContract(c);
            return Redirect("/Wallet");
        }

        public ActionResult Detail(int id)
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
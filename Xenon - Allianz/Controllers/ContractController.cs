using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
namespace Xenon___Allianz.Controllers
{
    public class ContractController : Controller
    {
        
        // GET: Contract
        public ActionResult Index(String id)
        {
            List<ContractModel> l = new List<ContractModel>();
            foreach (var item in Database.contracts)
            {
                if (item.Wallet.Equals(id))
                {
                    
                    l.Add(item);
                }
                    
            }
            Session["currentWallet"] = id;
            ViewBag.service = id;
            return View(l);
        }

        public ActionResult Create(String id)
        {
            ViewBag.Wallet = id;
            Session["currentWallet"] = id;
            return View();
        }

        public ActionResult AddContract(ContractModel c)
        {
            string s = (string)(Session["currentWallet"]);
            c.Wallet = s;
            //c.Wallet = Session["currentWallet"].ToString();
            Database.contracts.Add(c);
            return Redirect("/Contract/Index/"+s);
        }
    }

    
}
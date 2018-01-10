using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.BusinessLogic.Controllers;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Models;

namespace Xenon___Allianz.Controllers
{
    public class DatabaseController : Controller
    {

        // GET: Database
        public ActionResult Index()
        {
            FillDatabase();
            return Redirect("/Login");
        }
        private static void FillDatabase()
        {
            /** FILL USER **/
            User sous = new User()
            {
                Id = new Guid(),
                Username = "sous",
                Password = "pass",
                Mail = "sous@xenon.com",
                Status = "souscripteur",
                GeographicZone = new Guid()

            };

            User admin = new User()
            {
                Id = new Guid(),
                Username = "admin",
                Password = "pass",
                Mail = "admin@xenon.com",
                Status = "admin",
                GeographicZone = new Guid()
            };
            User manager = new User()
            {
                Id = new Guid(),
                Username = "manager",
                Password = "pass",
                Mail = "manager@xenon.com",
                Status = "manager",
                GeographicZone = new Guid()
            };
            User collaborateur = new User()
            {
                Id = new Guid(),
                Username = "collaborateur",
                Password = "pass",
                Mail = "collaborateur@xenon.com",
                Status = "collaborateur",
                GeographicZone = new Guid()
            };
            DataAccessAction.user.Register(sous);
            DataAccessAction.user.Register(admin);
            DataAccessAction.user.Register(manager);
            DataAccessAction.user.Register(collaborateur);

            /** FILL WALLET **/


            Wallet sport = new Wallet() { Service = "sport" };
            Wallet defense = new Wallet() { Service = "defense" };
            Wallet bank = new Wallet() { Service = "bank" };
            Wallet technology = new Wallet() { Service = "technology" };
            Wallet transport = new Wallet() { Service = "transport" };
            Wallet plastic = new Wallet() { Service = "plastic" };
            Wallet textile = new Wallet() { Service = "textile" };
            List<Wallet> lw = new List<Wallet>
            {
                new Wallet() { Service = "health" },
                new Wallet() { Service = "defense" },
                new Wallet() { Service = "sport" },
                new Wallet() { Service = "bank" },
                new Wallet() { Service = "technology" },
                new Wallet() { Service = "plastic" }
            };
            foreach (var item in lw)
            {
                DataAccessAction.wallet.AddWallet(item, sous.Id);
            }
            
            DataAccessAction.wallet.AddWallet(textile, manager.Id);
           
            generateContract(lw);
            /** FILL CONTRACT **/
        }

        public static void generateContract(List<Wallet> lw)
        {
            List<Contract> lc = new List<Contract>();
            Random rnd = new Random();
            DateTime d;
            for (int i = 0; i < lw.Count; i++)
            {
                for (int j = 0; j < rnd.Next(5,15); j++)
                {
                    d = new DateTime(rnd.Next(2010, 2025), rnd.Next(1, 12), rnd.Next(1, 28));
                    DataAccessAction.contract.AddContract(new Contract()
                    {
                        Company = lw[i].Service +" "+ j,
                        Cover = rnd.Next(1, 100),
                        Start = d,
                        End = d.AddDays(rnd.Next(30, 30 * 12)),
                        Negociable = (rnd.Next(0, 10) > 5) ? true : false,
                        Prime = rnd.Next(100000, 1000000),
                        Rompu = (rnd.Next(0, 10) > 5) ? true : false,
                        Value = rnd.Next(1000000, 50000000),
                        Wallet = lw[i].Id,
                    });
                }

            }

        }
    }
}
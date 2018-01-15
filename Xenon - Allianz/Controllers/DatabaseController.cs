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
            /** FILL GEOGRAPHIC ZONE **/
            GeographicZone world = new GeographicZone()
            {

                Name = "World",
                Father = new Guid()
            };
            DataAccessAction.geographicZone.AddGeographicZone(world);
            GeographicZone europe = new GeographicZone()
            {
                Name = "Europe",
                Father = world.Id
            };
            DataAccessAction.geographicZone.AddGeographicZone(europe);
            GeographicZone france = new GeographicZone()
            {
                Name = "France",
                Father = europe.Id,
            };
            GeographicZone england = new GeographicZone()
            {
                Name = "England",
                Father = europe.Id
            };
            DataAccessAction.geographicZone.AddGeographicZone(france);
            DataAccessAction.geographicZone.AddGeographicZone(england);

            /** FILL USER **/
            User sous = new User()
            {
                Id = new Guid(),
                Username = "sous",
                Password = "pass",
                Mail = "sous@xenon.com",
                Status = "souscripteur",
                GeographicZone = world.Id,
            };

            User admin = new User()
            {
                Id = new Guid(),
                Username = "admin",
                Password = "pass",
                Mail = "admin@xenon.com",
                Status = "admin",
                GeographicZone = world.Id,
            };
            User manager = new User()
            {
                Id = new Guid(),
                Username = "manager",
                Password = "pass",
                Mail = "manager@xenon.com",
                Status = "manager",
                GeographicZone = europe.Id
            };
            User collaborateur = new User()
            {
                Id = new Guid(),
                Username = "collaborateur",
                Password = "pass",
                Mail = "collaborateur@xenon.com",
                Status = "collaborateur",
                GeographicZone = france.Id
            };
            DataAccessAction.user.Register(sous);
            DataAccessAction.user.Register(admin);
            DataAccessAction.user.Register(manager);
            DataAccessAction.user.Register(collaborateur);

            /** FILL WALLET **/



            Wallet textile = new Wallet() {
                Service = "textile",
                Image = "http://www.logoground.com/uploads/201612016-07-144914158textiles-logo.jpg"
            };
            List<Wallet> lw = new List<Wallet>
            {
                new Wallet() {
                    Service = "health",
                    Image = "http://freedesignfile.com/upload/2016/05/Green-medical-health-logos-design-vector-05.jpg"
                },
                new Wallet() {
                    Service = "defense",
                    Image = "https://stocklogos-pd.s3.amazonaws.com/styles/logo-medium-alt/logos/image/1424377465-a61786215a22f67da35e3fa9347f22ca.png?itok=Yze7BSsy"
                },
                new Wallet() {
                    Service = "sport",
                    Image = "http://hddfhm.com/images/clipart-sports-logos-10.jpg"
                },
                new Wallet() {
                    Service = "bank",
                    Image = "http://www.fsroundtable.org/wp-content/uploads/2015/06/dot-bank-logo-website.png"
                },
                new Wallet() {
                    Service = "technology",
                    Image = "https://thumb1.shutterstock.com/display_pic_with_logo/1864790/429855787/stock-vector-tech-logo-technology-logo-element-429855787.jpg"
                },
                new Wallet() {
                    Service = "plastic",
                    Image = "https://botw-pd.s3.amazonaws.com/styles/logo-thumbnail/s3/0011/5708/brand.gif?itok=cW1XHoHd"
                }
            };
            foreach (var item in lw)
            {
                DataAccessAction.wallet.AddWallet(item, sous.Id);
            }

            DataAccessAction.wallet.AddWallet(textile, manager.Id);

            generateContract(lw);
            lw = new List<Wallet>()
            {
                textile
            };
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
                for (int j = 0; j < rnd.Next(10, 35); j++)
                {
                    d = new DateTime(rnd.Next(2010, 2025), rnd.Next(1, 12), rnd.Next(1, 28));
                    DataAccessAction.contract.AddContract(new Contract()
                    {
                        Company = lw[i].Service + " " + j,
                        Cover = rnd.Next(1, 100),
                        Start = d,
                        End = d.AddDays(rnd.Next(30, 30 * 12)),
                        Negociable = (rnd.Next(0, 10) > 5) ? true : false,
                        Prime = rnd.Next(100000, 1000000),
                        Rompu = (rnd.Next(0, 10) > 5) ? true : false,
                        Value = rnd.Next(1000000, 50000000),
                        Wallet = lw[i].Id,
                        Position = DataAccessAction.wallet.NumberOfContractsByWalletId(lw[i].Id) + 1
                    });
                }

            }

        }
    }
}
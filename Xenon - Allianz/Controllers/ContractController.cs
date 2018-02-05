using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon___Allianz.DataAccess;
using Xenon.BusinessLogic.Models;
using Newtonsoft.Json;

namespace Xenon___Allianz.Controllers

{
    public class ContractController : Controller
    {
        /* */


        /* WEBSITE WEB SERVICE*/
        public ActionResult Index(PaginationModel pm)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }

            if (((string)Session["XenonStatus"]).Equals("souscripteur") ||
                ((string)Session["XenonStatus"]).Equals("manager"))
            {
                Guid geoid = (Guid)Session["XenonGeoId"];
                ContractListModel clm = GetContractByWalletId(pm.WalletId, geoid);
                return View(clm);
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
            Guid geoid = (Guid)Session["XenonGeoId"];
            var s = Utils.ToGeographicZoneModel(DataAccessAction.geographicZone.GetAllAvailableGeographicZones());
            CreateContractModel cs = new CreateContractModel
            {
                GeographicZoneModel = s,
                WalletId = id,
                WalletName = DataAccessAction.wallet.GetWalletById(id).Service,
                UserId = geoid
            };
            return View(cs);
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
                Wallet = c.Wallet,
                Position = DataAccessAction.wallet.NumberOfContractsByWalletId(c.Wallet) + 1
            };
            DataAccessAction.contract.AddContract(contract,c.GeographicZoneId);
            foreach (var item in c.GeographicZoneId)
            {
                DataAccessAction.geographicZone.AddContractScope(contract.Id, item);
            }
            Console.WriteLine(c);
            return Redirect("/Wallet");
        }

        public ActionResult Detail(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            Guid userId = (Guid)Session["XenonUserId"];
            Contract item = DataAccessAction.contract.GetContractById(id);
            ContractModel contract = new ContractModel()
            {
                Id = item.Id,
                Start = item.Start.ToString() ,
                End = item.End.ToString(),
                Cover = item.Cover,
                Negociable = item.Negociable,
                Prime = item.Prime,
                Rompu = item.Rompu,
                Company = item.Company,
                Wallet = item.Wallet,
                WalletName = DataAccessAction.wallet.GetWalletById(item.Wallet).Service,
                Value = item.Value,
                GeographicZones = Utils.ToGeographicZoneModel(DataAccessAction.contract.GetGeographicZoneByContractId(item.Id)),
                Initial = DataAccessAction.wallet.GetScopeWalletByWalletIdAndUserId(userId,item.Wallet),
            };

            //contract.WalletName = ;


            return View(contract);
        }

        public ActionResult Edit(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            Contract item = DataAccessAction.contract.GetContractById(id);
            string st = item.Start.ToString().Split(' ')[0];
            ContractModel contract = new ContractModel()
            {
                Id = item.Id,
                Start = item.Start.Month.ToString("D2") + "/" + item.Start.Day.ToString("D2") + "/" + item.Start.Year ,
                End = item.End.Month.ToString("D2") + "/" + item.End.Day.ToString("D2") + "/" + item.End.Year,
                Cover = item.Cover,
                Negociable = item.Negociable,
                Prime = item.Prime,
                Rompu = item.Rompu,
                Company = item.Company,
                Wallet = item.Wallet,
                WalletName = DataAccessAction.wallet.GetWalletById(item.Wallet).Service,
                Value = item.Value,
                GeographicZones = Utils.ToGeographicZoneModel(DataAccessAction.contract.GetGeographicZoneByContractId(item.Id)),
            };

            EditContractModel ecm = new EditContractModel
            {
                Contract = contract,
                GeographicZoneModel = Utils.ToGeographicZoneModel(DataAccessAction.geographicZone.GetAllAvailableGeographicZones())
            };
            return View(ecm);
        }
        public ActionResult ValidEdit(ContractModel c)
        {
            
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
                Wallet = c.Wallet,
                Position = DataAccessAction.wallet.NumberOfContractsByWalletId(c.Wallet) + 1
            };
            DataAccessAction.contract.EditContract(c.Id,contract);
            /*foreach (var item in c.GeographicZoneId)
            {
                DataAccessAction.geographicZone.AddContractScope(contract.Id, item);
            }*/
            return Redirect("/Contract/Detail?id="+c.Id);
            //return Redirect("Detail");

        }
        /* API WEB SERVICE */

        public String IndexApi(PaginationModel pm)
        {
            if (Session["XenonUserId"] == null)
            {
                return JsonConvert.SerializeObject(new ContractListModel());
            }

            if (((string)Session["XenonStatus"]).Equals("souscripteur") ||
                ((string)Session["XenonStatus"]).Equals("manager"))
            {
                Guid geoid = (Guid)Session["XenonGeoId"];
                ContractListModel clm = GetContractByWalletId(pm.WalletId, geoid);
                return JsonConvert.SerializeObject(clm);
            }

            return JsonConvert.SerializeObject(new ContractListModel());
        }

        public String CreateApi(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return JsonConvert.SerializeObject(new CreateContractModel());
            }
            ViewBag.Wallet = id;
            Session["currentWallet"] = id;
            Guid geoid = (Guid)Session["XenonGeoId"];
            var s = Utils.ToGeographicZoneModel(DataAccessAction.geographicZone.GetAllAvailableGeographicZones());
            CreateContractModel cs = new CreateContractModel
            {
                GeographicZoneModel = s,
                WalletId = id,
                WalletName = DataAccessAction.wallet.GetWalletById(id).Service,
                UserId = geoid
            };
            return JsonConvert.SerializeObject(cs);
        }

        public void AddContractApi(ContractModel c)
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
                Wallet = c.Wallet,
                Position = DataAccessAction.wallet.NumberOfContractsByWalletId(c.Wallet) + 1
            };
            DataAccessAction.contract.AddContract(contract, c.GeographicZoneId);
            foreach (var item in c.GeographicZoneId)
            {
                DataAccessAction.geographicZone.AddContractScope(contract.Id, item);
            }
            Console.WriteLine(c);
            
        }

        public String DetailApi(Guid id)
        {
            if (Session["XenonUserId"] == null)
            {
                return JsonConvert.SerializeObject(new ContractModel());
            }
            Contract item = DataAccessAction.contract.GetContractById(id);
            ContractModel contract = new ContractModel()
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
                Value = item.Value,
                GeographicZones = Utils.ToGeographicZoneModel(DataAccessAction.contract.GetGeographicZoneByContractId(item.Id)),
            };

            //contract.WalletName = ;


            return JsonConvert.SerializeObject(contract);
        }

        /* END OF API WEB SERVICE */


        /** FUNCTION DEFINITION **/

        public ContractListModel GetContractByWalletId(Guid walletid, Guid geoid)
        {
            List<ContractModel> l = new List<ContractModel>();

            foreach (var item in DataAccessAction.contract.GetContractByWalletId(walletid, geoid))
            {
                l.Add(new ContractModel()
                {
                    Id = item.Id,
                    Start = item.Start.Year + "/" + item.Start.Month.ToString("D2") + "/" + item.Start.Day.ToString("D2"),
                    End = item.End.ToString(),
                    Cover = item.Cover,
                    Negociable = item.Negociable,
                    Prime = item.Prime,
                    Rompu = item.Rompu,
                    Company = item.Company,
                    Wallet = item.Wallet,
                    WalletName = "",
                    Value = item.Value,
                    //GeographicZones = Utils.ToGeographicZoneModel(item.GeographicZones)
                });
            }
            Session["currentWallet"] = walletid;
            ViewBag.service = walletid;
            Guid userId = (Guid)(Session["XenonUserId"]);
            ContractListModel clm = new ContractListModel()
            {
                ContractList = l,
                NumberOfContractInWallet = DataAccessAction.wallet.NumberOfContractsByWalletId(walletid),
                WalletName = DataAccessAction.wallet.GetWalletById(walletid).Service,
                Scope = (DataAccessAction.wallet.GetScopeWalletByWalletIdAndUserId(userId, walletid) ? "Inital" : "Extend")

            };

            return clm;

        }
    }







}
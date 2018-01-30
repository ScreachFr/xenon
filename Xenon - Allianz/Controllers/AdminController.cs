using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.DataAccess;

using Xenon.BusinessLogic.Models;
using Xenon___Allianz.Models;
using Newtonsoft.Json;

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
            if (Session["XenonStatus"] != null && ((string)Session["XenonStatus"]).Equals("admin"))
            {


                List<UserModel> lu = new List<UserModel>();
                foreach (var item in DataAccessAction.user.GetAllUsers())
                {
                    //if (item.Status.Equals("admin"))
                    //{
                    GeographicZone gz = DataAccessAction.geographicZone.GetGeographicZoneById(item.GeographicZone);
                    lu.Add(new UserModel()
                    {
                        Id = item.Id,
                        Username = item.Username,
                        Mail = item.Mail,
                        Status = item.Status,
                        GeographicZone = item.GeographicZone,
                        GeographicZoneName = (gz == null) ? "" : gz.Name

                    });

                    /*else
                    {
                        lu.Add(new UserModel()
                        {
                            Id = item.Id,
                            Username = item.Username,
                            Mail = item.Mail,
                            Status = item.Status,
                            //GeographicZone = item.GeographicZone,
                            GeographicZoneName = ""

                        });
                    }*/
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
                        NumberOfContract = 0,
                    });
                }
                return View(lw);
            }
            return Redirect("/");
        }

        public ActionResult GeographicZone()
        {
            List<GeographicZoneModel> l = Utils.ToGeographicZoneModel(DataAccessAction.geographicZone.GetAllAvailableGeographicZones());

            return View(l); 
        }

        public ActionResult Contracts()

        {

            if (((string)Session["XenonStatus"]).Equals("admin"))
            {
                List<ContractModel> lc = Utils.ToContractModel(DataAccessAction.contract.GetAllContract());
                
                return View(lc);
            }
            return Redirect("/");
        }

        public ActionResult RegisterUser()

        {
            List<GeographicZoneModel> l = Utils.ToGeographicZoneModel(DataAccessAction.geographicZone.GetAllAvailableGeographicZones());
            RegisterUserModel rum = new RegisterUserModel
            {
                GeographicZoneList = l
            };
            return View(rum);
        }
        public ActionResult RegisterUserAux(UserModel user)
        {
            Guid id = Utils.RandomGeographicZone();
            if (user.GeographicZone != null)
            {
                id = user.GeographicZone;
            }
            User u = new User()
            {
                Id = new Guid(),
                Username = user.Username,
                Password = Utils.GeneratePassword(),
                Mail = Utils.GenerateMail(user.Username),
                Status = user.Status,
                GeographicZone = id,
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

        public ActionResult ShowStatusToValid()
        {
            List<StatusToValid> upm = new List<StatusToValid>();
            foreach (var item in DataAccessAction.admin.GetUpdateStatus(true))
            {
                upm.Add(new StatusToValid
                {
                    AnswerTimeStamp = new DateTime(),
                    Id = item.Id,
                    State = item.State,
                    NewStatus = item.NewStatus,
                    OldStatus = item.OldStatus,
                    Path = item.Path,
                    SubmitTimeStamp = item.SubmitTimeStamp,
                    UserId =item.UserId,
                    Username = DataAccessAction.user.GetUserById(item.UserId).Username
                    
                });

            }
            return View(upm);
        }
        public ActionResult ShowAllUpdateStatus()
        {
            List<StatusToValid> upm = new List<StatusToValid>();
            foreach (var item in DataAccessAction.admin.GetUpdateStatus(true))
            {
                upm.Add(new StatusToValid
                {
                    AnswerTimeStamp = new DateTime(),
                    Id = item.Id,
                    State = item.State,
                    NewStatus = item.NewStatus,
                    OldStatus = item.OldStatus,
                    Path = item.Path,
                    SubmitTimeStamp = item.SubmitTimeStamp,
                    UserId = item.UserId,
                    Username = DataAccessAction.user.GetUserById(item.UserId).Username

                });
            }
            foreach (var item in DataAccessAction.admin.GetUpdateStatus(false))
            {
                upm.Add(new StatusToValid
                {
                    AnswerTimeStamp = new DateTime(),
                    Id = item.Id,
                    State = item.State,
                    NewStatus = item.NewStatus,
                    OldStatus = item.OldStatus,
                    Path = item.Path,
                    SubmitTimeStamp = item.SubmitTimeStamp,
                    UserId = item.UserId,
                    Username = DataAccessAction.user.GetUserById(item.UserId).Username

                });
            }
            return View(upm);
        }

        public FileResult DownloadFile(Guid id)
        {
            string path = DataAccessAction.admin.GetUpdateStatusById(id).Path;
            return new FilePathResult(Server.MapPath(path), "application/pdf");
        }
        public ActionResult AcceptUpdateStatus(Guid id)
        {
            DataAccessAction.admin.AcceptUpdateStatusUser(id);
            return Redirect("/Admin/Users");
        }
        public ActionResult RefuseUpdateStatus(Guid id)
        {
            DataAccessAction.admin.RefuseUpdateStatusUser(id);
            return Redirect("/Admin/Users");
        }

        public ActionResult AddWalletToUser(Guid id)
        {
            User u = DataAccessAction.user.GetUserById(id);
            UserModel us = new UserModel
            {
                Id = u.Id,
                Username = u.Username
            };
            List<WalletModel> wallets = new List<WalletModel>();
            foreach (var item in DataAccessAction.wallet.GetWalletNotInUserScope(id))
            {
                wallets.Add(new WalletModel
                {
                    Id = item.Id,
                    Service = item.Service
                });
            }

            AddWalletToUserContentModel acm = new AddWalletToUserContentModel
            {
                User = us,
                Wallets = wallets
            };
            return View(acm);
        }
        public ActionResult AddWalletToUserValid(AddWalletToUserModel auwm)
        {
            foreach (var item in auwm.WalletId)
            { //4BFCB6CB-9D05-E811-8AD0-484520A48417
                DataAccessAction.wallet.AddScope(auwm.UserId, item, true);
            }
            return Redirect("/Admin");
        }

        /* API WEB SERVICE */

        public string IndexApi()
        {
            return JsonConvert.SerializeObject(Index());
        }

        public string UsersApi()
        {
            return JsonConvert.SerializeObject(Users());
        }

        public string WalletsApi()
        {
            return JsonConvert.SerializeObject(Wallets());
        }

        public string RegisterUserApi()
        {
            return JsonConvert.SerializeObject(RegisterUser());
        }
            
        public string ContractsApi()
        {
            return JsonConvert.SerializeObject(Contracts());
        }

        public string GeographicZoneApi()
        {
            return JsonConvert.SerializeObject(GeographicZone());
        }

        public string AddWalletApi()
        {
            return JsonConvert.SerializeObject(AddWallet());
        }

        public string UpdateSatusApi()
        {
            return JsonConvert.SerializeObject(UpdateSatus());
        }

        public string UpdateStatusValidationApi(UpdateStatusModel usm)
        {
            return JsonConvert.SerializeObject(UpdateStatusValidation(usm));
        }

        public string ShowStatusToValidApi()
        {
            return JsonConvert.SerializeObject(ShowStatusToValid());
        }

        public string ShowAllUpdateStatusApi()
        {
            return JsonConvert.SerializeObject(ShowStatusToValid());
        }

        public string DownloadFileApi(Guid id)
        {
            return JsonConvert.SerializeObject(DownloadFile(id));
        }

        public string AcceptUpdateStatusApi(Guid id)
        {
            return JsonConvert.SerializeObject(AcceptUpdateStatus(id));
        }

        public string RefuseUpdateStatusApi(Guid id)
        {
            return JsonConvert.SerializeObject(RefuseUpdateStatus(id));
        }

        public string AddWalletToUserApi(Guid id)
        {
            return JsonConvert.SerializeObject(AddWalletToUser(id));
        }

        public string AddWalletToUserValidApi(AddWalletToUserModel auwm)
        {
            return JsonConvert.SerializeObject(AddWalletToUserValid(auwm));
        }

        /* END OF API WEB SERVICE */




    }
}
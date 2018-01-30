using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;
using System.IO;
using Newtonsoft.Json;

namespace Xenon___Allianz.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["XenonUserId"] == null)
            {
                return Redirect("/");
            }
            Guid userId = (Guid)(Session["XenonUserId"]);
            User u = DataAccessAction.user.GetUserById(userId);
            List<StatusToValid> usm = new List<StatusToValid>();
            foreach (var item in DataAccessAction.user.GetMyUpdateStatus(userId))
            {
                usm.Add(new StatusToValid
                {
                    UserId = item.UserId,
                    AnswerTimeStamp = item.AnswerTimeStamp,
                    State = item.State,
                    NewStatus = item.NewStatus,
                    OldStatus = item.OldStatus,
                    Path = item.Path,
                    SubmitTimeStamp = item.SubmitTimeStamp
                });
            }
            UserModel us = new UserModel()
            {
                Id = u.Id,
                Username = u.Username,
                GeographicZone = (u.GeographicZone == null) ? u.GeographicZone : new Guid(),
                GeographicZoneName = DataAccessAction.geographicZone.GetGeographicZoneById(u.GeographicZone).Name,
                Mail = u.Mail,
                Status = u.Status,
                UpdateStatus = usm,
            };
            return View(us);
        }

        public FileResult DownloadFile()
        {
            return new FilePathResult(Server.MapPath("/File/Email.pdf"), "application/pdf");
        }

        public ActionResult UpdateStatus()
        {

            return View();
        }
        public ActionResult UpdatingStatus(UpdateStatusModel usm)
        {

            Guid id = (Guid)Session["XenonUserId"];
            string connectedSession = (string)(Session["XenonStatus"]);
            if (Path.GetExtension(usm.File.FileName).Equals(".pdf"))
            {
                string filename = Path.GetFileName(usm.File.FileName);
                usm.File.SaveAs(Server.MapPath(path: "~/File/") + filename);
                UpdateStatus updateStatus = new Xenon.BusinessLogic.Models.UpdateStatus
                {
                    State = 1,
                    NewStatus = usm.NewStatus,
                    OldStatus = connectedSession,
                    Path = "~/File/" + filename,
                    UserId = id
                };
                DataAccessAction.admin.AddUpdateStatusUser(updateStatus);
                //DataAccessAction.user.EditStatus(id, usm.NewStatus,"");
                return Redirect("/");
            }
            return View("UpdateStatus");

        }

        /* API WEB SERVICE */

        public string IndexApi()
        {
            return JsonConvert.SerializeObject(Index());
        }

        public string DownloadFileApi()
        {
            return JsonConvert.SerializeObject(DownloadFile());
        }

        public string UpdateStatusApi()
        {
            return JsonConvert.SerializeObject(UpdateStatus());
        }

        public string UpdatingStatusApi(UpdateStatusModel usm)
        {
            return JsonConvert.SerializeObject(UpdatingStatus(usm));
        }
    
    /* END OF API WEB SERVICE */
    }

}
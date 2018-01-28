using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;
using System.IO;

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
            UserModel us = new UserModel()
            {
                Id = u.Id,
                Username = u.Username,
                GeographicZone = (u.GeographicZone == null)? u.GeographicZone : new Guid(),
                GeographicZoneName = DataAccessAction.geographicZone.GetGeographicZoneById(u.GeographicZone).Name,
                Mail = u.Mail,
                Status = u.Status
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
                    InProgress = true,
                    NewStatus= usm.NewStatus,
                    OldStatus = connectedSession,
                    Path = "~/File/"+filename,
                    UserId = id
                };
                DataAccessAction.admin.AddUpdateStatusUser(updateStatus);
                //DataAccessAction.user.EditStatus(id, usm.NewStatus,"");
                return Redirect("/");
            }
            return View("UpdateStatus");
            
        }
    }

}
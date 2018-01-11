using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;

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
                GeographicZone = u.GeographicZone,
                GeographicZoneName = DataAccessAction.geographicZone.GetGeographicZoneById(u.GeographicZone).Name,
                Mail = u.Mail,
                Status = u.Status
            };
            return View(us);
        }
    }
}
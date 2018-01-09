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

            /*
            DataAccessAction.user.Register(new User()
            {
                Id = new Guid(),
                Username = "sous",
                Password = "pass",
                Mail = "sous@xenon.com",
                Status = "souscripteur"
            });
            DataAccessAction.user.Register(new User()
            {
                Id = new Guid(),
                Username = "admin",
                Password = "pass",
                Mail = "admin@xenon.com",
                Status = "admin"
            });
            DataAccessAction.user.Register(new User()
            {
                Id = new Guid(),
                Username = "manager",
                Password = "pass",
                Mail = "manager@xenon.com",
                Status = "manager"
            });
            */
            


            return Redirect("/Login");
        }
    }
}
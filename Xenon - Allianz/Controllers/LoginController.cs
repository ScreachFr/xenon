using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class LoginController : Controller
    {
        List<User> users = new List<User>();


        // GET: Log
        public ActionResult Index()
        {

            return View("index", "_LayoutLogin");
        }

        [HttpPost]
        public ActionResult Login(UserModel u)
        {

            Console.Write(u);
            if (ModelState.IsValid)
            {

                User usr = DataAccessAction.user.Login(u.Username, u.Password);
                    if (usr != null)
                    {

                        Session["XenonUsername"] = usr.Username;
                        Session["XenonStatus"] = usr.Status;
                        Session["XenonUserId"] = usr.Id;
                        Session["ErrorPassWord"] = null;
                        return Redirect("/Home");
                    
                    }
                    else
                    {
                        Session["ErrorPassWord"] = "Login ou mot de passe incorect.";
                        
                    }
                


                return Redirect("/Login");

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["XenonUsername"] = null;
            Session["XenonStatus"] = null;
            Session["XenonUserId"] = null;
            return Redirect("/Login");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class LoginController : Controller
    {
        List<UserModel> users = new List<UserModel>();


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

                UserModel usr = DataAccessAction.user.Login(u);
                    if (usr != null)
                    {

                        Session["XenonUsername"] = usr.Username;
                        Session["XenonType"] = usr.Status;
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
            Session["XenonType"] = null;
            Session["XenonUserId"] = null;
            return Redirect("/Login");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.BusinessLogic.Models;
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
        public ActionResult FillUsers()
        {
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Login(UserModel u)
        {

            Console.Write(u);
            if (ModelState.IsValid)
            {
                using (var ctx = new DataContextModel())
                {
                    /* var myUser = (from us in ctx.Users
                                 where us.Username.Equals("mohamed")
                                 select us).ToArray();

                     if (myUser == null)
                     {
                         ctx.Users.Add(new Xenon.BusinessLogic.Models.User() { Username = u.Username, Password = u.Password, Mail = u.Mail, Type = "Collaborateur" });
                         return Redirect("/Login");
                     }
                     */
                    UserModel usr = Database.Login(u);
                    if (usr != null)
                    {

                        Session["XenonUsername"] = usr.Username;
                        Session["XenonType"] = usr.Status;
                        Session["XenonUserId"] = usr.Id;
                        Session["ErrorPassWord"] = null;
                        return Redirect("/Home");

                        /*
                        Session["ErrorPassWord"] = "username : "+usr.Username+"\n type : "+usr.Status+"\nid :"+usr.Id;
                        return Redirect("/Login");
                        */
                    }
                    else
                    {
                        Session["ErrorPassWord"] = "Login ou mot de passe incorect.";
                        ViewBag.Message = "Login ou mot de passe incorect.";
                    }
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
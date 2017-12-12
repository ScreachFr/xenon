using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
    public class LoginController : Controller
    {
        List<UserModel> users = new List<UserModel>();


        // GET: Log
        public ActionResult Index()
        {

            return View("index","_LayoutLogin");
        }
        public ActionResult FillUsers()
        {
           return Redirect("/");
        }
        
        [HttpPost]
        public ActionResult Login(UserModel u)
        {
            Session["XenonUsername"] = "mohamed";
            Console.Write(u);
            if (ModelState.IsValid)
            {
                foreach (UserModel item in Database.users)
                {
                    if (u.Username.Equals("mohamed") && u.Password.Equals("pass"))
                    {
                        Session["XenonUsername"] = u.Username;
                        return Redirect("/Home");
                    }
                    if (item.Username.Equals(u.Username))
                    {
                        if (item.Password.Equals(u.Password))
                        {
                            Session["XenonUsername"] = u.Username;
                            return Redirect("/Home");
                        }
                        else
                        {

                        }
                    }
                    else
                    {                        
                    }    
                }

                return Redirect("/Login");


                //ViewBag.Message = "Your application description page.";
                //return View();
            }

            //return Redirect("/Home/Index");
            return View();
        }

        public ActionResult Logout()
        {
            Session["XenonUsername"] = null;
            return Redirect("/Log");
        }
    }
}
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
            
            Console.Write(u);
            if (ModelState.IsValid)
            {
                //Session["XenonUsername"] = "mohamed";
                /*if (u.Username.Equals("mohamed") && u.Password.Equals("pass"))
                {
                    Session["XenonUsername"] = u.Username;
                    return Redirect("/Home");
                }*/
                foreach (UserModel item in Database.users)
                {
                    
                    if (item.Username.Equals(u.Username))
                    {
                        if (item.Password.Equals(u.Password))
                        {
                            Session["XenonUsername"] = u.Username;
                            Session["XenonType"] = item.Type;
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
            return Redirect("/Login");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xenon.BusinessLogic.Controllers;
using Xenon___Allianz.DataAccess;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Controllers
{
  public class DatabaseController : Controller
  {

    // GET: Database
    public ActionResult Index()
    {

      Database d = new Database();
            //DataAccessAction.user.Register(new Xenon.BusinessLogic.Models.User());
      return Redirect("/Login");
    }
  }
}
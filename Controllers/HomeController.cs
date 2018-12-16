using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet3.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
﻿using Projet3.Models;
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
        private BlogEntities db = new BlogEntities();

        // GET: ?idCategorie=1
        public ActionResult Index(int? idCategorie)
        {
            return View(db.DerniersArticlesListe(idCategorie).ToList());
        }
    }
}
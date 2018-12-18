using Projet3.Models;
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
        public ActionResult Index(int? idCategorie, string search)
        {
            ViewBag.Categories = db.Categorie.ToList();
            var articles = db.DerniersArticlesListe(idCategorie, search).ToList();
            return View(articles);
        }
    }
}
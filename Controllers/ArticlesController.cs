using Projet3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet3.Controllers
{
    [Authorize(Roles = "user")]
    public class ArticlesController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Articles/1
        public ActionResult FicheArticle(int id)
        {
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        // POST: Articles/DepotCommentaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DepotCommentaire(int id)
        {
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            if (string.IsNullOrEmpty(Request.Form["comment"]))
            {
                ModelState.AddModelError(string.Empty, "Le commentaire est vide, veuillez saisir un commentaire");

                return View("FicheArticle", article);
            }

            Lecteur lecteur = db.Lecteur.FirstOrDefault(x => x.pseudo == User.Identity.Name);

            Commentaire commentaire = new Commentaire();
            commentaire.idArticle = id;
            commentaire.idLecteur = lecteur.idLecteur;
            commentaire.contenu = Request.Form["comment"];
            commentaire.date = DateTime.Now;

            db.Commentaire.Add(commentaire);
            db.SaveChanges();

            return RedirectToAction("FicheArticle", new { id = id });
        }

        // GET: Articles/Liste?idCategorie=1&search=php&page=1
        public ActionResult Liste(int? idCategorie, string search, int? page)
        {
            int limit = 10;
            int offset = 0;

            if (null != page && page > 1)
            {
                offset = limit * (page.GetValueOrDefault() - 1);
            }

            int nbArticles = db.DerniersArticlesListe(idCategorie, search, null, null).ToList().Count;
            decimal decNbPages = Convert.ToDecimal(nbArticles) / limit;
            ViewBag.NbPages = Convert.ToInt32(Math.Ceiling(decNbPages));
            ViewBag.Categories = db.Categorie.ToList();
            var articles = db.DerniersArticlesListe(idCategorie, search, limit, offset).ToList();
            return View(articles);
        }
    }
}
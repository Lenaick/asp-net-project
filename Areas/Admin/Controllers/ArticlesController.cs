using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet3.Areas.Admin.Models;
using Projet3.Models;

namespace Projet3.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Admin/Articles
        public ActionResult Index()
        {
            return View(db.ArticlesListe().ToList());
        }

        // GET: Admin/Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            ViewBag.idCategorie = new SelectList(db.Categorie, "idCategorie", "libelle");
            return View();
        }

        // POST: Admin/Articles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel model)
        {
            Article article = new Article();

            if (ModelState.IsValid)
            {
                article.date_publication = DateTime.Now;
                article.idCategorie = model.idCategorie;
                article.titre = model.titre;
                article.contenu = model.contenu;
                article.publie = model.publie;
                article.image = model.image;

                db.Article.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategorie = new SelectList(db.Categorie, "idCategorie", "libelle", article.idCategorie);
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategorie = new SelectList(db.Categorie, "idCategorie", "libelle", article.idCategorie);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleViewModel model, int id)
        {
            var article = db.Article.Find(id);
            if (article == null)
            {
                return new HttpNotFoundResult();
            }

            if (ModelState.IsValid)
            {
                article.idCategorie = model.idCategorie;
                article.titre = model.titre;
                article.contenu = model.contenu;
                article.addedum = model.addedum;
                article.publie = model.publie;
                article.image = model.image;
                article.date_addedum = null;

                if (!string.IsNullOrEmpty(model.addedum))
                {
                    article.date_addedum = DateTime.Now;
                }

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategorie = new SelectList(db.Categorie, "idCategorie", "libelle", article.idCategorie);
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Article.Find(id);
            db.Article.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

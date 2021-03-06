﻿using Projet3.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Projet3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : BaseController
    {
        private BlogEntities db = new BlogEntities();

        // GET: Admin/Categories
        [RestoreModelStateFromTempData]
        public ActionResult Index()
        {
            return View(db.CategoriesListe().ToList());
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "libelle", Exclude = "idCategorie")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categorie.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Admin/Categories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategorie,libelle")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Admin/Categories/Delete/5
        [SetTempDataModelState]
        public ActionResult Delete(int? id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            // Sécurité - vérifier que la catégorie ne comporte pas d'articles
            if (categorie.Article.Count > 0)
            {
                ModelState.AddModelError("", "Impossible de supprimer cette catégorie, elle contient des articles");
            }
            else
            {
                db.Categorie.Remove(categorie);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult UniqueNameExist(string libelle, int? idCategorie)
        {
            var validateName = db.Categorie.FirstOrDefault
                                (x => x.libelle == libelle && x.idCategorie != idCategorie);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet3.Models;

namespace Projet3.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class LecteursController : BaseController
    {
        private BlogEntities db = new BlogEntities();

        // GET: Admin/Lecteurs
        public ActionResult Index()
        {
            return View(db.Lecteur.ToList());
        }

        public ActionResult AltBlocked(int? idLecteur)
        {
            if (idLecteur == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecteur lecteur = db.Lecteur.Find(idLecteur);
            if (lecteur == null)
            {
                return HttpNotFound();
            }
            lecteur.bloque = !lecteur.bloque;
            db.Entry(lecteur).State = EntityState.Modified;
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

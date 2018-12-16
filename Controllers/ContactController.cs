using Projet3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projet3.Controllers
{
    [Authorize(Roles = "user")]
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ConfigurationManager.AppSettings["EmailRecipient"]);
                mail.From = new MailAddress("noreply@astuce-de-geek.fr");
                mail.Subject = model.sujet;
                mail.Body = model.message;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.astuce-de-geek.fr";
                smtpClient.Send(mail);

                TempData["alert"] = "Votre demande a bien été envoyé";

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
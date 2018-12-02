using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Projet3.Areas.Admin.Models;
using Projet3.Models;

namespace Projet3.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private BlogEntities databaseManager = new BlogEntities();

        public AccountController()
        {
        }

        #region Login methods    
        /// <summary>  
        /// GET: /Account/Login    
        /// </summary>  
        /// <param name="returnUrl">Return URL parameter</param>  
        /// <returns>Return login view</returns>  
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }

                ViewBag.ReturnURL = null;
                if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
                {
                    returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
                }
                if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl) && !string.Equals(returnUrl, "/"))
                {
                    ViewBag.ReturnURL = returnUrl;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View();
        }
        /// <summary>  
        /// POST: /Account/Login    
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <param name="returnUrl">Return URL parameter</param>  
        /// <returns>Return login view</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginInfo = this.databaseManager.LoginAdminByUsernamePassword(model.Email, model.Password).ToList();
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        var logindetails = loginInfo.First();
                        this.SignInUser(logindetails.admin_identifiant, false);
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            string decodedUrl = Server.UrlDecode(returnUrl);
                            return this.RedirectToLocal(decodedUrl);
                        }
                        return this.RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Échec de l'authentification.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View(model);
        }
        #endregion
        #region Log Out method.    
        /// <summary>  
        /// POST: /Account/LogOff    
        /// </summary>  
        /// <returns>Return log off action</returns>
        public ActionResult LogOff()
        {
            // Setting.    
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            // Sign Out.    
            authenticationManager.SignOut();
            // Info.    
            return this.RedirectToAction("Login", "Account");
        }
        #endregion
        #region Helpers    
        #region Sign In method.    
        /// <summary>  
        /// Sign In User method.    
        /// </summary>  
        /// <param name="username">Username parameter.</param>  
        /// <param name="isPersistent">Is persistent parameter.</param>  
        private void SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            
        }
        #endregion
        #region Redirect to local method.    
        /// <summary>  
        /// Redirect to local method.    
        /// </summary>  
        /// <param name="returnUrl">Return URL parameter.</param>  
        /// <returns>Return redirection action</returns>  
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            return this.RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion
    }
}
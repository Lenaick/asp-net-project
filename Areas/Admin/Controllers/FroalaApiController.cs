using System;
using System.Web.Mvc;

namespace Projet3.Areas.Admin.Controllers
{
    public class FroalaApiController : Controller
    {
        public ActionResult UploadImage()
        {
            string uploadPath = "/Public/";

            try
            {
                return Json(FroalaEditor.Image.Upload(System.Web.HttpContext.Current, uploadPath));
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public ActionResult LoadImages()
        {
            string uploadPath = "/Public/";

            try
            {
                return Json(FroalaEditor.Image.List(uploadPath), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public ActionResult DeleteImage()
        {
            try
            {
                FroalaEditor.Image.Delete(HttpContext.Request.Form["src"]);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
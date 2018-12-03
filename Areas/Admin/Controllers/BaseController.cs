using System.Web.Mvc;

namespace Projet3.Areas.Admin.Controllers
{
    public abstract partial class BaseController : Controller
    {
        protected class SetTempDataModelStateAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
                filterContext.Controller.TempData["ModelState"] =
                   filterContext.Controller.ViewData.ModelState;
            }
        }

        protected class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                if (filterContext.Controller.TempData.ContainsKey("ModelState"))
                {
                    filterContext.Controller.ViewData.ModelState.Merge(
                        (ModelStateDictionary)filterContext.Controller.TempData["ModelState"]);
                }
            }
        }
    }
}
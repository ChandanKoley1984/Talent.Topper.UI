using System;
using System.Web.Mvc;

namespace Talent.Topper.UI.Controllers
{
    public class BaseController : Controller, IActionFilter, IExceptionFilter
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ModelStateValidations(filterContext);
            base.OnActionExecuting(filterContext);
        }       

        protected override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext.Exception);
            base.OnException(filterContext);
        }

        private void Log(Exception exception)
        {
            //Log Write Here 
        }

        private static void ModelStateValidations(ActionExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                filterContext.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = filterContext.Controller.TempData
                };
            }
        }
    }
}
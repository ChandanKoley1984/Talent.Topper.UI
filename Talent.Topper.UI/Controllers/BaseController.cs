using System;
using System.Web.Mvc;
using Talent.Topper.UI.Helpers;

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
            //ModelStateValidations(filterContext);
            base.OnActionExecuting(filterContext);
        }       

        protected override void OnException(ExceptionContext filterContext)
        {            
            filterContext.ExceptionHandled = true;
            Log(filterContext.Exception);
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }

        private void Log(Exception exception)
        {
            //Log Write Here 
            //Logger logger = new Logger();
            //logger.WriteLog(exception.Message);
        }

        //private static void ModelStateValidations(ActionExecutingContext filterContext)
        //{
        //    var viewData = filterContext.Controller.ViewData;

        //    //if (!viewData.ModelState.IsValid)
        //    //{
        //    //    filterContext.Result = new ViewResult
        //    //    {
        //    //        ViewData = viewData,
        //    //        TempData = filterContext.Controller.TempData
        //    //    };
        //    //}
        //}
    }
}
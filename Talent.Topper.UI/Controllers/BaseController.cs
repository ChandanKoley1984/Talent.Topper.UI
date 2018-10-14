using System.Web.Mvc;

namespace Talent.Topper.UI.Controllers
{
    public class BaseController : Controller, IActionFilter,IExceptionFilter
    {        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

    }
}
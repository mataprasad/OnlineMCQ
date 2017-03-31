using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using Web.Models;

namespace Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class TraceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Web.Helper.Logger.Instance.LogTrace(String.Format("Exist from Action Method '{0}.{1}'", 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName));
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Web.Helper.Logger.Instance.LogTrace(String.Format("Entered in Action Method '{0}.{1}'", 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, 
                filterContext.ActionDescriptor.ActionName));
        }

        //public override void OnResultExecuted(ResultExecutedContext filterContext) { }
        //public override void OnResultExecuting(ResultExecutingContext filterContext) { }
    }

    public sealed class ErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var http=filterContext.Controller.ControllerContext.RequestContext.HttpContext;
            filterContext.ExceptionHandled = true;
            Web.Helper.Logger.Instance.LogError(String.Format("=====================================\n\rTime : {0}\n\rError : {1}\n\rStackTrace : {2}",
                   DateTime.UtcNow.ToString(), filterContext.Exception.Message, filterContext.Exception.StackTrace));
            if (http.Request.IsAjaxRequest())
            {
                http.Response.StatusCode = 500;
                http.Response.Write("Unable to response the request, there is some server error.");
            }
            else
            {
                http.Response.Redirect("~/home/Error500");
            }
        }
    }
}

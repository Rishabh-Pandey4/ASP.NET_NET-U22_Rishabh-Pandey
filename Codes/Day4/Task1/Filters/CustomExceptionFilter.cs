using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

using log4net;

namespace Task1.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(CustomExceptionFilter));

        public void OnException( ExceptionContext context)
        {
            
            

            string Contr = context.RouteData.Values["controller"].ToString();
            string Actmethod = context.RouteData.Values["action"].ToString();

            _logger.Error("Controller Name: " + Contr);
            _logger.Error("Action Name: " + Actmethod);
            _logger.Error(context.Exception.Message);

            context.ExceptionHandled = true;
            context.Result = new ViewResult() { ViewName = "CustomErrorPage" };
        }
    }
}

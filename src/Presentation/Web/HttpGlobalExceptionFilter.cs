using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;

namespace OBilet.CaseStudy.Presentation.Web
{

    public partial class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception.InnerException?.GetType() == typeof(ValidationException))
            {
                var validate = context.Exception.InnerException as ValidationException;

                //foreach (var error in validate.Errors)
                //    context.ModelState.AddModelError(string.Empty, error.ErrorMessage);
                 
                context.Result = new RedirectToActionResult("Index", "Home", new { ErrorMessage = validate.Errors.FirstOrDefault()?.ErrorMessage });
                //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            context.ExceptionHandled = true;
        }
    }
}

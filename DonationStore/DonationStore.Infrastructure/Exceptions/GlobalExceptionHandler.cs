using System.Data.SqlClient;
using System.Net;
using DonationStore.Infrastructure.GenericMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace DonationStore.Infrastructure.Exceptions
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public static string TipoRetorno = DefautlTexts.ApplicationResultType;

        public override void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = TipoRetorno;

            if (context.Exception is BusinessException)
            {
                context.Result = new JsonResult(context.Exception.Message);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is AuthorizationException)
            {
                context.Result = new JsonResult(context.Exception.Message);
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(context.Exception.InnerException?.Message ?? context.Exception.Message);
            }
        }
    }
}

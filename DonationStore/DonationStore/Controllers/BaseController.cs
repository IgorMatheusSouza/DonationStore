using DonationStore.Infrastructure.GenericMessages;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DonationStore.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult ReturnError(HttpStatusCode statusCode, string message = null)
        {
            return statusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(message),
                HttpStatusCode.Unauthorized => Unauthorized(message),
                HttpStatusCode.Forbidden => Forbid(message),
                HttpStatusCode.NotFound => NotFound(message),
                HttpStatusCode.MethodNotAllowed => ReturnError(statusCode, message),
                HttpStatusCode.UnsupportedMediaType => ReturnError(statusCode, message),
                HttpStatusCode.InternalServerError => ReturnError(statusCode, message),
                HttpStatusCode.BadGateway => ReturnError(statusCode, message),
                HttpStatusCode.GatewayTimeout => ReturnError(statusCode, message),

                _ => ReturnError(statusCode, ErrorMessages.GenericError)
            };
        }

        protected IActionResult ReturnCreated(object data = null) => StatusCode((int)HttpStatusCode.Created, data);
    }
}
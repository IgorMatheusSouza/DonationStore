using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.GenericMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
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

        protected void SaveUserSession(LoginUserViewModel loginUser) 
        {
            HttpContext.Session.SetString(nameof(loginUser.Name), loginUser.Name);
            HttpContext.Session.SetString(nameof(loginUser.Token), loginUser.Token);
            HttpContext.Session.SetString(nameof(loginUser.Email), loginUser.Email);
        }

        protected LoginUserViewModel GetUserSession()
        {
            var model = new LoginUserViewModel();
            return new LoginUserViewModel()
            {
                Token = HttpContext.Session.GetString(nameof(model.Token)),
                Email = HttpContext.Session.GetString(nameof(model.Email)),
                Name = HttpContext.Session.GetString(nameof(model.Name))
            };
        }

        protected void EndUserSession()
        {
            HttpContext.Session.Clear();
        }
    }
}
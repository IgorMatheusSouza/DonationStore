using DonationStore.Application.Queries.User;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUserService UserService;

        public BaseController(IUserService userService)
        {
            UserService = userService;
        }

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

        protected IActionResult OkCreated(object data = null) => StatusCode((int)HttpStatusCode.Created, data);

        protected void SaveUserSession(UserViewModel loginUser) 
        {
            HttpContext.Session.SetString(nameof(loginUser.Name), loginUser.Name);
            HttpContext.Session.SetString(nameof(loginUser.Token), loginUser.Token);
            HttpContext.Session.SetString(nameof(loginUser.Email), loginUser.Email);
            HttpContext.Session.SetString(nameof(loginUser.Id), loginUser.Id.ToString());
        }

        protected async Task<UserViewModel> GetUserSession()
        {
            var model = new UserViewModel();
            var userModel = new UserViewModel()
            {
                Token = HttpContext.Session.GetString(nameof(model.Token)),
                Email = HttpContext.Session.GetString(nameof(model.Email)),
                Name = HttpContext.Session.GetString(nameof(model.Name))
            };

            var id = HttpContext.Session.GetString(nameof(model.Id));

            if (id.IsEmpty())
            {
                var user = await UserService.GetUser(new GetUserQuery(userModel.Email));

                if(user.Token != userModel.Token)
                    throw new AuthorizationException(ErrorMessages.AuthError);

                userModel.Id = user.Id;
            }
            else 
            {
                userModel.Id = Guid.Parse(id);
            }

            return userModel;
        }

        protected void EndUserSession()
        {
            HttpContext.Session.Clear();
        }
    }
}
﻿using DonationStore.Infrastructure.Constants;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.GenericMessages;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DonationStore.Infrastructure.Security
{
    public class AuthorizationFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext) 
        {
            var userToken = (string)actionContext.HttpContext.Request.Headers[SystemConstantValues.HeaderUserTokenString];

            var sessionToken = actionContext.HttpContext.Session.GetString(SystemConstantValues.TokenViewModelString);

            if (userToken == sessionToken)
            {
                return;
            }
            else if (sessionToken.IsEmpty() && !userToken.IsEmpty())
            {
                actionContext.HttpContext.Session.SetString(SystemConstantValues.TokenViewModelString, userToken);
                actionContext.HttpContext.Session.SetString("Name", actionContext.HttpContext.Request.Headers["username"]);
                actionContext.HttpContext.Session.SetString("Email", actionContext.HttpContext.Request.Headers["useremail"]);
            }
            else
                throw new AuthorizationException(ErrorMessages.AuthError);
        }
    }
}
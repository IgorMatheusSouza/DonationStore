using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command) 
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            var response = await AuthenticationService.RegisterUser(command);
            return ReturnCreated(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.AuthenticationService = authenticationService;
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command) 
        {
            var response = await this.AuthenticationService.RegisterUser(command);
            return Ok(response);
        }
    }
}

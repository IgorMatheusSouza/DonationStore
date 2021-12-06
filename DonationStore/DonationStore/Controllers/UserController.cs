using DonationStore.Application.Commands.User;
using DonationStore.Application.Queries.User;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService) : base(userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [AuthorizationFilter]
        public async Task<IActionResult> GetLoggedUser()
        {
            var userSession = await GetUserSession();
            return Ok(await UserService.GetUser(new GetUserQuery(userSession.Email)));
        }

        [HttpPost]
        [Route("phone")]
        [AuthorizationFilter]
        public async Task<IActionResult> GetLoggedUser([FromBody] RegisterPhoneNumberCommand command)
        {
            var userSession = await GetUserSession();
            command.UserId = userSession.Id;
            await UserService.RegisterPhone(command);
            return OkCreated();
        }
    }
}

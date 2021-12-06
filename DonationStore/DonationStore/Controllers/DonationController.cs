using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class DonationsController : BaseController
    {
        private readonly IDonationService DonationService;

        public DonationsController(IDonationService donationService, IUserService userService) : base(userService)
        {
            DonationService = donationService;
        }

        [HttpPost]
        [AuthorizationFilter]
        public async Task<IActionResult> RegisterDonation([FromBody] RegisterDonationCommand command)
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            command.LoginUser = await GetUserSession();
            await DonationService.RegisterDonation(command);

            return OkCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetDonations([FromQuery] int? page, [FromQuery] int? quantity)
        {
            var query = new GetDonationsQuery(page, quantity);
            var donations = await DonationService.GetDonations(query);

            return Ok(donations);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDonation([FromRoute] Guid id)
        {
            var donations = await DonationService.GetDonation(new GetDonationQuery(id));
            return Ok(donations);
        }

        [HttpPost]
        [AuthorizationFilter]
        [Route("acquire")]
        public async Task<IActionResult> AcquireDonation([FromBody] AcquireDonationCommand command)
        {
            var user = await GetUserSession();
            command.UserId = user.Id;

            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            await DonationService.AcquireDonation(command);
            return OkCreated();
        }

        [HttpGet]
        [AuthorizationFilter]
        [Route("acquire")]
        public async Task<IActionResult> GetDonationAcquisition()
        {
            var user = await GetUserSession();
            var result = await DonationService.GetDonationAcquisitions(new GetDonationAcquisitionsQuery(user.Id));
            return Ok(result);
        }
    }
}

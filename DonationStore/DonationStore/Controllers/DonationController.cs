using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.Services.Abstractions;
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

        public DonationsController(IDonationService donationService)
        {
            DonationService = donationService;
        }

        [HttpPost]
        [AuthorizationFilter]
        public async Task<IActionResult> RegisterDonation([FromBody] RegisterDonationCommand command)
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            command.LoginUser = GetUserSession();
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
    }
}

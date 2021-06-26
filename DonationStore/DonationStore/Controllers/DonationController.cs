﻿using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Services.Abstractions;
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
        public async Task<IActionResult> RegisterDonation([FromBody] RegisterDonationCommand command)
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            await DonationService.RegisterDonation(command);

            return ReturnCreated();
        }
    }
}

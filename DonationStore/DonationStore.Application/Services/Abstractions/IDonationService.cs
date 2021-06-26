using DonationStore.Application.Commands.Donation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public interface IDonationService
    {
        Task RegisterDonation(RegisterDonationCommand registerDonationCommand); 
    }
}

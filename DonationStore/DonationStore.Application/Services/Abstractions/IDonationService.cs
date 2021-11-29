using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public interface IDonationService
    {
        Task RegisterDonation(RegisterDonationCommand registerDonationCommand);

        Task<List<DonationViewModel>> GetDonations(GetDonationsQuery query);

        Task<DonationViewModel> GetDonation(GetDonationQuery query);

        Task AcquireDonation(AcquireDonationCommand command);
    }
}

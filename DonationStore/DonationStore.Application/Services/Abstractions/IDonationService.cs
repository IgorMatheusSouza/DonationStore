using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public interface IDonationService
    {
        Task RegisterDonation(RegisterDonationCommand registerDonationCommand);

        Task<List<DonationViewModel>> GetDonations(GetDonationsQuery query);

        Task<DonationViewModel> GetDonation(GetDonationQuery query);

        Task AcquireDonation(AcquireDonationCommand command);

        Task<List<DonationViewModel>> GetDonationAcquisitions(GetDonationAcquisitionsQuery getDonationAcquisitions);

        Task<List<DonationViewModel>> GetUserDonations(GetUserDonationsQuery query);

        Task ChangeDonationAcquisitionStatus(ChangeAcquisitionStatusCommand command);
    }
}

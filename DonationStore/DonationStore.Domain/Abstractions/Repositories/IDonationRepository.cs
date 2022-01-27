using DonationStore.Domain.Enities;
using DonationStore.Enums.DomainEnums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IDonationRepository
    {
        Task RegisterDonation(Donation donation);
        Task<List<Donation>> GetDonations(int page, int quantity, string searchWord, string searchPlace);
        Task<Donation> GetDonation(Guid id);
        Task ChangeStatus(DonationEnum donationEnum, Guid donationId);
        Task<List<Donation>> GetUserDonations(Guid id);
    }
}

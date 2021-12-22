using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IDonationAcquisitionRepository
    {
        Task CreateDonationAcquisition(Guid donationId, Guid UserId);

        Task<List<DonationAcquisition>> GetDonationAcquisitions(Guid userId);

        Task<Donation> GetDonationAcquisition(Guid donationId);

        Task ChangeAcquisitionStatus(Guid donationAcquisitionId, DonationAcquisitionEnum status);
    }
}

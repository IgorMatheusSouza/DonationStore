using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Repository.Repositories
{
    public class DonationAcquisitionRepository : IDonationAcquisitionRepository
    {
        private readonly DonationStoreContext DonationStoreContext;

        public DonationAcquisitionRepository(DonationStoreContext donationStoreContext)
        {
            DonationStoreContext = donationStoreContext;
        }

        public async Task CreateDonationAcquisition(Guid donationId, Guid userId) 
        {
            var donationAcquisition = new DonationAcquisition() { UserId = userId.ToString(), DonationId = donationId, IsActive = true, Status = DonationAcquisitionEnum.Active, CreationDate = DateTime.Now };
            await DonationStoreContext.AddAsync(donationAcquisition);
            await DonationStoreContext.SaveChangesAsync();
        }
    }
}

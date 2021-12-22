using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<DonationAcquisition>> GetDonationAcquisitions(Guid userId)
        {
            return await DonationStoreContext.DonationAcquisition.Where(x => x.IsActive && x.UserId == userId.ToString())
                                                                 .Include(x => x.Donation).ThenInclude(x => x.User)
                                                                 .Include(x => x.Donation).ThenInclude(x => x.Images)
                                                                 .ToListAsync();
        }

        public async Task ChangeAcquisitionStatus(Guid donationAcquisitionId, DonationAcquisitionEnum status)
        {
            var donationAcquisition = await DonationStoreContext.DonationAcquisition.FindAsync(donationAcquisitionId);
            donationAcquisition.Status = status;
            await DonationStoreContext.SaveChangesAsync();
        }

        public async Task<Donation> GetDonationAcquisition(Guid donationId)
        {
            return await DonationStoreContext.Donations.Include(x => x.Acquisitions).FirstOrDefaultAsync(x => x.Id == donationId && x.Acquisitions.Any(a => a.Status == DonationAcquisitionEnum.Active));
        }
    }
}

using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Enities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Enums.EnumServices;
using DonationStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonationStore.Infrastructure.Extensions;

namespace DonationStore.Repository.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DonationStoreContext DonationStoreContext;
        public DonationRepository(DonationStoreContext donationStoreContext)
        {
            DonationStoreContext = donationStoreContext;
        }

        public async Task ChangeStatus(DonationEnum donationEnum, Guid donationId)
        {
            var donation = await DonationStoreContext.Donations.FindAsync(donationId);
            donation.Status = donationEnum;
            await DonationStoreContext.SaveChangesAsync();
        }

        public async Task<Donation> GetDonation(Guid id)
        {
            return await DonationStoreContext.Donations.Include(x => x.Images).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Donation>> GetDonations(int page, int quantity, string searchWord, string searchPlace)
        {
            IList<DonationEnum> openStatus = DonationEnumService.GetOpenDonationStatus();
            var result = DonationStoreContext.Donations.Where(x => openStatus.Contains(x.Status)).Include(x => x.Images).AsQueryable();

            if (!searchWord.IsEmpty())
                result = result.Where(x => x.Title.ToLower().Contains(searchWord)).AsQueryable();

            if (!searchPlace.IsEmpty())
                result = result.Where(x => x.City.ToLower().Contains(searchPlace) || x.District.ToLower().Contains(searchPlace)).AsQueryable();

            return await result.Skip(page * quantity).Take(quantity).ToListAsync();
        }

        public async Task<List<Donation>> GetUserDonations(Guid id)
        {
            return await DonationStoreContext.Donations.Include(x => x.Images)
                                                       .Include(x => x.Acquisitions.Where(y => y.Status != DonationAcquisitionEnum.Cancelled))
                                                       .ThenInclude(x => x.User)
                                                       .Where(x => x.User.Id == id.ToString())
                                                       .ToListAsync();
        }

        public async Task RegisterDonation(Donation donation)
        {
            donation.CreationDate = DateTime.Now;
            await DonationStoreContext.AddAsync(donation);
            await DonationStoreContext.SaveChangesAsync();
        }
    }
}
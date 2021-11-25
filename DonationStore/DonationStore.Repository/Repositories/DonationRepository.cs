using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Enities;
using DonationStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Repository.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DonationStoreContext DonationStoreContext;
        public DonationRepository(DonationStoreContext donationStoreContext)
        {
            DonationStoreContext = donationStoreContext;
        }

        public async Task<Donation> GetDonation(Guid id)
        {
            return await DonationStoreContext.Donations.Include(x => x.Images).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Donation>> GetDonations(int page, int quantity)
        {
            return await DonationStoreContext.Donations.Skip(page * quantity).Take(quantity).Include(x => x.Images).ToListAsync();
        }

        public async Task RegisterDonation(Donation donation)
        {
            donation.CreationDate = DateTime.Now;
            await DonationStoreContext.AddAsync(donation);
            await DonationStoreContext.SaveChangesAsync();
        }
    }
}
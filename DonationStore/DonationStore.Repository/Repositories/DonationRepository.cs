using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Enities;
using DonationStore.Repository.Context;
using System;
using System.Threading.Tasks;

namespace DonationStore.Repository.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private DonationStoreContext DonationStoreContext;
        public DonationRepository(DonationStoreContext donationStoreContext)
        {
            this.DonationStoreContext = donationStoreContext;
        }
        public async Task RegisterDonation(Donation donation)
        {
            donation.CreationDate = DateTime.Now;
            await DonationStoreContext.AddAsync(donation);
            await DonationStoreContext.SaveChangesAsync();
        }
    }
}
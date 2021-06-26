using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Enities;
using DonationStore.Repository.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}

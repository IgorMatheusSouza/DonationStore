using DonationStore.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IDonationRepository
    { 
        Task RegisterDonation(Donation donation);
    }
}

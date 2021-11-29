using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IDonationAcquisitionRepository
    {
        Task CreateDonationAcquisition(Guid donationId, Guid UserId);
    }
}

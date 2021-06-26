using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Abstractions.Factories
{
    public interface IDonationFactory
    {
        Donation Adapt(RegisterDonationCommand data);
    }
}

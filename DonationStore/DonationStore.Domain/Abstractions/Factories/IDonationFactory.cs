using DonationStore.Application.Commands.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Abstractions.Factories
{
    public interface IDonationFactory
    {
        Donation Adapt(RegisterDonationCommand data);

        List<DonationViewModel> Adapt(List<Donation> donations);

        DonationViewModel Adapt(Donation donation);

        List<DonationViewModel> Adapt(List<DonationAcquisition> result);
    }
}

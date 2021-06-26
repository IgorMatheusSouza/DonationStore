using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Factories
{
    public class DonationFactory : IDonationFactory
    {
        public Donation Adapt(RegisterDonationCommand data)
        {
            return new Donation()
            {
                Title = data.Title,
                Description = data.Description,
                City = data.City,
                State = data.State,
                ZipCode = data.ZipCode,
                Address = data.Address
            };
        }
    }

}

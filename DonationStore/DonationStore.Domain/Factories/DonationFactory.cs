using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using DonationStore.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Address = data.Address,
                District = data.District,
                Images = data.Images.Where(x => !x.FileName.IsEmpty()).Select(x => new DonationImage { 
                    FileName = x.FileName, 
                    CreationDate = DateTime.Now 
                }).ToList()
            };
        }
    }
}

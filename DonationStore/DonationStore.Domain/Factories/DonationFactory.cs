using DonationStore.Application.Commands.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
                ShowEmail = data.ShowEmail,
                Status = DonationEnum.Active,
                ShowPhoneNumber = data.ShowPhoneNumber,
                Images = data.Images.Where(x => !x.FileName.IsEmpty()).Select(x => new DonationImage { 
                    FileName = x.FileName, 
                    CreationDate = DateTime.Now 
                }).ToList()
            };
        }

        public List<DonationViewModel> Adapt(List<Donation> donations)
        {
            return donations.Select(data => new DonationViewModel()
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                City = data.City,
                State = data.State,
                ZipCode = data.ZipCode,
                Address = data.Address,
                District = data.District,
                CreationDate = data.CreationDate,
                Status = data.Status,
                Images = data.Images?.Select(x => new DonationImageModel
                {
                    FileName = x.FileName
                }).ToList() ?? default

            }).ToList();
        }

        public DonationViewModel Adapt(Donation data)
        {
            return new DonationViewModel()
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                City = data.City,
                State = data.State,
                ZipCode = data.ZipCode,
                Address = data.Address,
                District = data.District,
                CreationDate = data.CreationDate,
                ShowEmail = data.ShowEmail,
                Status = data.Status,
                ShowPhoneNumber = data.ShowPhoneNumber,
                Images = data.Images?.Select(x => new DonationImageModel
                {
                    FileName = x.FileName
                }).ToList() ?? default,
                User = new UserDetailViewModel() { Name = data.User.Name, Phone = data.User.PhoneNumber }

            };
        }

        public List<DonationViewModel> Adapt(List<DonationAcquisition> acquisitions)
        {
            List<DonationViewModel> result = new();

            foreach (var item in acquisitions)
            {
                var donation = Adapt(item.Donation);
                donation.DonationAcquisitions.Add(new() { CreationDate = item.CreationDate, Status = item.Status });
                result.Add(donation);
            }

            return result;
        }
    }
}
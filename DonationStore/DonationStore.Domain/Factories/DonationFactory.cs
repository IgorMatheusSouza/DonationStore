using DonationStore.Application.Commands.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
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
                AddressNumber = data.AddressNumber,
                ShowPhoneNumber = data.ShowPhoneNumber,
                Images = data.Images.Where(x => !x.FileName.IsEmpty()).Select(x => new DonationImage { 
                    FileName = x.FileName, 
                    CreationDate = DateTime.Now 
                }).ToList(),
                Latitude = data.Geocoding.Lat,
                Longitude = data.Geocoding.Lng
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
                AddressNumber = data.AddressNumber,
                Images = data.Images?.Select(x => new DonationImageModel
                {
                    FileName = x.FileName
                }).ToList() ?? default,
                Geocoding = new() { Lat = data.Latitude, Lng = data.Longitude  },
                DonationAcquisitions = data.Acquisitions?.Select(x =>
                                                new DonationAcquisitionViewModel() {
                                                    CreationDate = x.CreationDate,
                                                    Status = x.Status,
                                                    User = new UserDetailViewModel() { Name = x.User?.Name, Phone =  data.ShowPhoneNumber ? x.User?.PhoneNumber : DefautlTexts.PhoneNotVisible }
                                                }).ToList()

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
                User = new UserDetailViewModel() {
                    Name = data.User.Name,
                    Phone = data.ShowPhoneNumber ? data.User?.PhoneNumber : DefautlTexts.PhoneNotVisible, 
                    Email = data.ShowEmail ? data.User?.Email : DefautlTexts.EmailNotVisible
                }
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
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using System.Collections.Generic;
using IRequest = MediatR.IRequest;

namespace DonationStore.Application.Commands.Donation
{
    public class RegisterDonationCommand : Command, ICommand, IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public UserViewModel LoginUser { get; set; }
        public List<DonationImageModel> Images { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }

        public bool Validate()
        {
            if (Title.IsEmpty() || Description.IsEmpty())
                SetBadRequest(ValidationMessages.EmptyFields);

            var maxAllowedLength = SystemConstantValues.GenericMaxFieldLength;

            if (Title.Length > maxAllowedLength || Description.Length > maxAllowedLength || Address.Length > maxAllowedLength)
                SetBadRequest(ValidationMessages.MaxLengthError(maxAllowedLength));

            return IsValid;
        }
    }
}

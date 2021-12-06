using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using System;
using IRequest = MediatR.IRequest;

namespace DonationStore.Application.Commands.User
{
    public class RegisterPhoneNumberCommand : Command, ICommand, IRequest
    {
        public Guid UserId { get; set; }

        public string PhoneNumber { get; set; }

        public bool Validate()
        {
            if (PhoneNumber.IsEmpty() || PhoneNumber.Length < 8)
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}

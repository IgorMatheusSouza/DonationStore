using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using System;
using DonationStore.Infrastructure.Extensions;
using IRequest = MediatR.IRequest;
using DonationStore.Infrastructure.GenericMessages;

namespace DonationStore.Application.Commands.Donation
{
    public class AcquireDonationCommand : Command, ICommand, IRequest
    {
        public Guid DonationId { get; set; }

        public Guid UserId { get; set; }

        public bool Validate()
        {
            if (DonationId.IsEmptyOrInvalid() || UserId.IsEmptyOrInvalid())
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}

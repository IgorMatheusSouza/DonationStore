using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using System;
using IRequest = MediatR.IRequest;

namespace DonationStore.Application.Commands.Donation
{
    public class ChangeAcquisitionStatusCommand : Command, ICommand, IRequest
    {
        public Guid DonationId { get; set; }

        public DonationAcquisitionEnum Status { get; set; }

        public Guid UserId { get; set; }


        public bool Validate()
        {
            if (DonationId.IsEmptyOrInvalid() || (int)Status > 0)
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}

using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Commands.Authentication
{
    public class LogoutCommand : Command, ICommand, IRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public bool Validate()
        {
            if (Email.IsEmpty() || Token.IsEmpty())
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}

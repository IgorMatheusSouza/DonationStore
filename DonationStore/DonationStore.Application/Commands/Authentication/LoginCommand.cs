using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Application.Commands.Authentication
{
    public class LoginCommand : Command, ICommand, IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Validate()
        {
            if (Email.IsEmpty() || Password.IsEmpty())
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}

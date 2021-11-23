using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using MediatR;

namespace DonationStore.Application.Commands.Authentication
{
    public class RegisterUserCommand : Command, ICommand, IRequest<UserViewModel>
    {
        public string PasswordConfirmation { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Validate()
        {
            if (Name.IsEmpty() || Email.IsEmpty() || Password.IsEmpty())
                SetBadRequest(ValidationMessages.EmptyFields);

            return IsValid;
        }
    }
}
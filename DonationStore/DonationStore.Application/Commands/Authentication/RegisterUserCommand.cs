using DonationStore.Infrastructure.CQRS.Abstractions;
using DonationStore.Infrastructure.CQRS.Implementations;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;

namespace DonationStore.Application.Commands.Authentication
{
    public class RegisterUserCommand : Command<RegisterUserCommand>, ICommand
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
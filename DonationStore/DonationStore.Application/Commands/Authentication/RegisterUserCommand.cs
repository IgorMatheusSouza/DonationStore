using DonationStore.Infrastructure.CQRS.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Application.Commands.Authentication
{
    public class RegisterUserCommand : Command<RegisterUserCommand>
    {
        public RegisterUserCommand(RegisterUserCommand message) : base(message)
        {
        }

        public string PasswordConfirmation { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
